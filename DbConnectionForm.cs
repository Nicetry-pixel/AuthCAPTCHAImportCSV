using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class DbConnectionForm : Form
    {
        public DbConnectionForm()
        {
            InitializeComponent();

            txtServer.Text = "localhost";
            txtDatabase.Text = "tradeautoproduct";
            txtUser.Text = "root";
            txtPassword.Text = "root123";

            txtDatabase.Enabled = (GlobalConfig.UserRole == 1);
            btnRestore.Enabled = false;
            btnImportCsv.Enabled = false;
            btnContinue.Enabled = false;
        }

        private string BuildServerString()
        {
            return $"Server={txtServer.Text};Uid={txtUser.Text};Pwd={txtPassword.Text};" +
                   "Charset=utf8mb4";
        }

        private string BuildConnectionString()
        {
            return $"Server={txtServer.Text};Database={txtDatabase.Text};" +
                   $"Uid={txtUser.Text};Pwd={txtPassword.Text};" +
                   "Charset=utf8mb4";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(BuildConnectionString()))
                    conn.Open();

                MessageBox.Show("Подключение к серверу MySQL успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                GlobalConfig.ConnectionString = BuildConnectionString();

                btnRestore.Enabled = true;
                btnImportCsv.Enabled = true;
                btnContinue.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка подключения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRestore.Enabled = false;
                btnImportCsv.Enabled = false;
                btnContinue.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using (var importForm = new CsvImportForm())
                importForm.ShowDialog();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string sqlScript = File.ReadAllText(openFileDialog1.FileName);

                using (var conn = new MySqlConnection(BuildServerString()))
                {
                    conn.Open();
                    var script = new MySqlScript(conn, sqlScript);
                    script.Execute();
                }

                MessageBox.Show("База данных успешно восстановлена из dump!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка восстановления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вошли как Администратор. Настройки сохранены.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL dump (*.sql)|*.sql";
                sfd.FileName = "tradeautoproduct.sql";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string dumpPath = sfd.FileName;

                var psi = new ProcessStartInfo
                {
                    FileName = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                    Arguments = $"-u root -proot123 --default-character-set=utf8mb4 " +
                                $"--result-file=\"{dumpPath}\" tradeautoproduct",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                };

                try
                {
                    using (var proc = Process.Start(psi))
                    {
                        string err = proc.StandardError.ReadToEnd();
                        proc.WaitForExit();

                        if (proc.ExitCode == 0)
                            MessageBox.Show($"Дамп сохранён:\n{dumpPath}", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"Ошибка: {err}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось запустить mysqldump: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackUpForm back = new BackUpForm();
            back.ShowDialog();
            this.Hide();
            this.Close();  
        }
    }
}