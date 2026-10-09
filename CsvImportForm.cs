using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class CsvImportForm : Form
    {
        private static readonly Dictionary<string, string> ReferenceTables =
            new Dictionary<string, string>
        {
            { "Role",          "RoleName" },
            { "OrderStatus",   "StatusName" },
            { "Unit",          "UnitName" },
            { "Category",      "CategoryName" },
            { "Manufacturer",  "ManufacturerName" },
            { "Supplier",      "SupplierName" },
            { "ProductStatus", "ProductStatusName" },
            { "PickupPoint",   "Address" }
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

            string table = cmbTable.SelectedItem.ToString();
            string column = ReferenceTables[table];

            try
            {
                int inserted = ImportCsv(table, column, txtFilePath.Text);
                MessageBox.Show($"Импорт завершён. Добавлено записей: {inserted}.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ImportCsv(string table, string column, string filePath)
        {
            int inserted = 0;
            string[] lines = ReadAllLinesAutoEncoding(filePath);

            using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                conn.Open();

                using (var setCmd = new MySqlCommand("SET NAMES utf8mb4;", conn))
                    setCmd.ExecuteNonQuery();

                int expectedCols = CountNonIdColumns(conn, table);

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

                    bool ok = fields.Count == 1 ||
                              (fields.Count == expectedCols + 1 && IsAllDigits(fields[0]));
                    if (!ok)
                        throw new InvalidOperationException(
                            $"Строка {lineNo}: обнаружено {fields.Count} колонок, " +
                            $"ожидается 1 или {expectedCols + 1}.");

                    string value = fields.Count >= 2 && IsAllDigits(fields[0])
                        ? fields[1]
                        : fields[0];

                    value = value.Trim();
                    if (string.IsNullOrEmpty(value)) continue;

                    using (var cmd = new MySqlCommand(
                        $"INSERT IGNORE INTO `{table}` (`{column}`) VALUES (@v)", conn))
                    {
                        cmd.Parameters.AddWithValue("@v", value);
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