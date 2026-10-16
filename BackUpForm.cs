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
using System.Diagnostics;

namespace AuthCAPTCHAImportCSV
{
    public partial class BackUpForm : Form
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
            },
            { "Product", new List<string>
                    {
                        "ProductArticleNumber",
                        "ProductName",
                        "ProductDescription",
                        "CategoryID",
                        "ProductPhoto",
                        "ManufacturerID",
                        "SupplierID",
                        "UnitID",
                        "ProductCost",
                        "ProductMaxDiscount",
                        "ProductCurrentDiscount",
                        "ProductQuantityInStock",
                        "ProductStatusID"
                    }
            },
            { "Order", new List<string>
                    {
                        "OrderID",
                        "OrderStatusID",
                        "OrderDate",
                        "OrderDeliveryDate",
                        "OrderPickupPointID",
                        "OrderClientName",
                        "OrderCode"
                    }
            },
             { "OrderProduct", new List<string>
                    {
                        "OrderID",
                        "ProductArticleNumber",
                        "Quantity"
                    }
            },
            { "User", new List<string>
                    {
                        "UserID",
                        "UserSurname",
                        "UserName",
                        "UserPatronymic",
                        "UserLogin",
                        "UserPassword",
                        "UserRole"
                    }
            }
         };
        public BackUpForm()
        {
            InitializeComponent();

            cmbTable.Items.AddRange(new object[]
           {
                "Role", "OrderStatus", "Unit", "Category",
                "Manufacturer", "Supplier", "ProductStatus", "PickupPoint", "Product", "Order","OrderProduct","User"
           });

            cmbTable.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = saveFileDialog1.FileName;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text?.Trim();
            if (string.IsNullOrEmpty(filePath) || Path.GetExtension(filePath).ToLowerInvariant() != ".csv")
            {
                MessageBox.Show("Укажите корректный путь к CSV-файлу.", "Ошибка",
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
                int exported = ExportCsv(table, columns, filePath);
                MessageBox.Show($"Экспорт завершён. Записано строк: {exported}.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ExportCsv(string table, List<string> columns, string filePath)
        {
            int written = 0;

            using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                conn.Open();

                using (var setCmd = new MySqlCommand("SET NAMES utf8mb4;", conn))
                    setCmd.ExecuteNonQuery();

                // Формируем SELECT со всеми колонками
                string columnsList = string.Join(", ", columns.Select(c => $"`{c}`"));
                string sql = $"SELECT {columnsList} FROM `{table}`";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // Заголовок CSV: все колонки через запятую
                        string header = string.Join(",", columns.Select(EscapeCsvValue));
                        writer.WriteLine(header);

                        while (reader.Read())
                        {
                            var rowValues = new List<string>();
                            for (int i = 0; i < columns.Count; i++)
                            {
                                string value = reader.IsDBNull(i) ? "" : reader.GetValue(i)?.ToString() ?? "";
                                rowValues.Add(EscapeCsvValue(value));
                            }

                            writer.WriteLine(string.Join(",", rowValues));
                            written++;
                        }
                    }
                }
            }

            return written;
        }


        /// <summary>
        /// Экранирование значения для CSV: если есть кавычки, запятые, переносы — оборачиваем в "" и экранируем "" как "".
        /// </summary>
        private static string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            // Если есть спецсимволы — оборачиваем в кавычки и экранируем внутренние кавычки
            bool needsQuotes = value.Contains('"') || value.Contains(',') ||
                               value.Contains('\n') || value.Contains('\r');

            if (!needsQuotes)
                return value;

            StringBuilder sb = new StringBuilder();
            sb.Append('"');
            foreach (char c in value)
            {
                if (c == '"')
                    sb.Append("\"\""); // экранирование кавычки в CSV
                else
                    sb.Append(c);
            }
            sb.Append('"');

            return sb.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DbConnectionForm auth = new DbConnectionForm();
            auth.ShowDialog();
            Close();
        }

        private void BackUpForm_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (var sfd = new SaveFileDialog())
        //    {
        //        sfd.Filter = "SQL dump (*.sql)|*.sql";
        //        sfd.FileName = "tradeautoproduct.sql";

        //        if (sfd.ShowDialog() != DialogResult.OK)
        //            return;

        //        string dumpPath = sfd.FileName;

        //        var psi = new ProcessStartInfo
        //        {
        //            FileName = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
        //            Arguments = $"-u root -proot123 --default-character-set=utf8mb4 " +
        //                        $"--result-file=\"{dumpPath}\" tradeautoproduct",
        //            UseShellExecute = false,
        //            CreateNoWindow = true,
        //            RedirectStandardError = true
        //        };

        //        try
        //        {
        //            using (var proc = Process.Start(psi))
        //            {
        //                string err = proc.StandardError.ReadToEnd();
        //                proc.WaitForExit();

        //                if (proc.ExitCode == 0)
        //                    MessageBox.Show($"Дамп сохранён:\n{dumpPath}", "Успех",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                else
        //                    MessageBox.Show($"Ошибка: {err}", "Ошибка",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Не удалось запустить mysqldump: {ex.Message}", "Ошибка",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
    }
}
