using MySql.Data.MySqlClient;
using System;
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
            txtPassword.Text = "root";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка подключения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRestore.Enabled = false;
                btnImportCsv.Enabled = false;
                btnContinue.Enabled = false;
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
    }
}