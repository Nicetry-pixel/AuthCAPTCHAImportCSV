using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace AuthCAPTCHAImportCSV
{
    public partial class CsvImportForm : Form
    {
        private static readonly Dictionary<string, List<string>> ReferenceTables =
            new Dictionary<string, List<string>>
        {
            { "Role",       new List<string>  { "RoleName" } },
            { "OrderStatus", new List<string>  { "StatusName" } },
            { "Unit",        new List<string>  {"UnitName" } },
            { "Category",    new List<string> { "CategoryName" } },
            { "Manufacturer", new List<string> {"ManufacturerName" } },
            { "Supplier",    new List<string>  {"SupplierName" } },
            { "ProductStatus", new List<string> {"ProductStatusName" } },
            { "PickupPoint", new List<string>
                    {
                        "postal_code",
                        "city",
                        "street",
                        "house_number"
                    }
            }
        };

        public CsvImportForm()
        {
            InitializeComponent();
            cmbTable.Items.AddRange(new object[]
            {
                "Role", "OrderStatus", "Unit", "Category",
                "Manufacturer", "Supplier", "ProductStatus", "PickupPoint"
            });
            cmbTable.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = openFileDialog1.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Выберите CSV-файл.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string table = cmbTable.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(table) || !ReferenceTables.TryGetValue(table, out var columns))
            {
                MessageBox.Show("Не выбрана корректная таблица.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int inserted = ImportCsv(table, columns, txtFilePath.Text);
                MessageBox.Show($"Импорт завершён. Добавлено записей: {inserted}.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Исправленный ImportCsv: принимает List<string> columns и делает INSERT для всех колонок
        private int ImportCsv(string table, List<string> columns, string filePath)
        {
            int inserted = 0;
            string[] lines = ReadAllLinesAutoEncoding(filePath);

            using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                conn.Open();

                using (var setCmd = new MySqlCommand("SET NAMES utf8mb4;", conn))
                    setCmd.ExecuteNonQuery();

                int expectedCols = columns.Count;
                bool firstLine = true;
                int lineNo = 0;

                foreach (string raw in lines)
                {
                    lineNo++;
                    if (firstLine && chkHasHeader.Checked)
                    {
                        firstLine = false;
                        continue;
                    }
                    firstLine = false;

                    string line = raw.Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    var fields = ParseCsvLine(line);
                    if (fields.Count == 0) continue;

                    // Проверка: количество полей должно совпадать с количеством колонок для вставки
                    if (fields.Count != expectedCols)
                        throw new InvalidOperationException(
                            $"Строка {lineNo}: обнаружено {fields.Count} колонок, ожидается {expectedCols}.");

                    var values = fields.Select(f => f.Trim()).ToList();

                    // Динамический INSERT: INSERT IGNORE INTO `table` (`col1`, `col2`, ...) VALUES (@v0, @v1, ...)
                    string columnsList = string.Join(", ", columns.Select(c => $"`{c}`"));
                    string paramList = string.Join(", ", Enumerable.Range(0, columns.Count).Select(i => $"@v{i}"));

                    using (var cmd = new MySqlCommand(
                        $"INSERT IGNORE INTO `{table}` ({columnsList}) VALUES ({paramList})", conn))
                    {
                        for (int i = 0; i < columns.Count; i++)
                            cmd.Parameters.AddWithValue($"@v{i}", values[i]);

                        inserted += cmd.ExecuteNonQuery();
                    }
                }
            }

            return inserted;
        }

        private static int CountNonIdColumns(MySqlConnection conn, string table)
        {
            string sql =
                "SELECT COUNT(*) FROM information_schema.columns " +
                "WHERE table_schema = DATABASE() AND table_name = @t " +
                "AND column_key <> 'PRI' AND extra NOT LIKE '%auto_increment%'";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@t", table);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private static bool IsAllDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            foreach (char c in s)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        private static List<string> ParseCsvLine(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            sb.Append('"');
                            i++;
                        }
                        else inQuotes = false;
                    }
                    else sb.Append(c);
                }
                else
                {
                    if (c == '"') inQuotes = true;
                    else if (c == ',' || c == ';' || c == '\t')
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    else sb.Append(c);
                }
            }
            result.Add(sb.ToString());
            return result;
        }

        private static string[] ReadAllLinesAutoEncoding(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);

            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                return File.ReadAllLines(path, Encoding.UTF8);

            if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                return File.ReadAllLines(path, Encoding.Unicode);
            if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
                return File.ReadAllLines(path, Encoding.BigEndianUnicode);

            try
            {
                var strictUtf8 = new UTF8Encoding(false, true);
                strictUtf8.GetString(bytes);
                return File.ReadAllLines(path, new UTF8Encoding(false));
            }
            catch
            {
                return File.ReadAllLines(path, Encoding.GetEncoding(1251));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}