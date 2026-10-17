using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class SelectUserForm : Form
    {
        private bool _showPersonalData = false;

        public SelectUserForm()
        {
            InitializeComponent();
            Load += SelectUserForm_Load;
        }

        private void SelectUserForm_Load(object sender, EventArgs e)
        {
            // Доступ только для администратора (роль 1)
            if (GlobalConfig.UserRole != 2)
            {
                MessageBox.Show("Доступ к управлению пользователями разрешён только администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            lblUser.Text = GlobalConfig.UserFIO;

            chkShowPersonalData.CheckedChanged += ChkShowPersonalData_CheckedChanged;

            LoadUsers();
        }

        private void ChkShowPersonalData_CheckedChanged(object sender, EventArgs e)
        {
            _showPersonalData = chkShowPersonalData.Checked;
            MaskPersonalData();
        }

        private void LoadUsers()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT
                               u.`UserSurname`,
                               u.`UserName`,
                               u.`UserPatronymic`,
                               r.`RoleName`
                        FROM `user` u
                        LEFT JOIN Role r ON r.`RoleID` = u.`UserRole`
                        ORDER BY u.`UserID`";

                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvUsers.DataSource = dt;
                        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                ConfigureColumns();
                MaskPersonalData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvUsers.Columns.Contains("UserSurname"))
                dgvUsers.Columns["UserSurname"].Visible = false;
            if (dgvUsers.Columns.Contains("UserName"))
                dgvUsers.Columns["UserName"].Visible = false;
            if (dgvUsers.Columns.Contains("UserPatronymic"))
                dgvUsers.Columns["UserPatronymic"].Visible = false;
            if (dgvUsers.Columns.Contains("RoleName"))
                dgvUsers.Columns["RoleName"].HeaderText = "Роль";
            if (!dgvUsers.Columns.Contains("FullNameCol"))
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "FullnameCol";
                col.HeaderText = "ФИО";
                col.FillWeight = 150;
                dgvUsers.Columns.Insert(0, col);
            }
        }

        /// <summary>
        /// Маскирует ФИО, логин и пароль, если режим защиты включён.
        /// </summary>
        private void MaskPersonalData()
        {
            if (dgvUsers == null || dgvUsers.Rows.Count == 0) return;

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.IsNewRow) continue;

                var bound = row.DataBoundItem as DataRowView;
                if (bound == null) continue;

                // ФИО — маскируем фамилию и имя, отчество сокращаем
                string surname = bound["UserSurname"]?.ToString() ?? "";
                string name = bound["UserName"]?.ToString() ?? "";
                string patronymic = bound["UserPatronymic"]?.ToString() ?? "";
                string displayFIO = "";

                if (_showPersonalData)
                {
                    displayFIO = $"{surname} {name} {patronymic}".Trim();
                }
                else
                {
                    string initials = "";
                    if (!string.IsNullOrWhiteSpace(name)) initials += name.Substring(0, 1).ToUpper() + ".";
                    if (!string.IsNullOrWhiteSpace(patronymic)) initials += patronymic.Substring(0, 1).ToUpper() + ".";
                    displayFIO = $"{surname} {initials}".Trim();
                }
                row.Cells["FullNameCol"].Value = displayFIO;
            }
        }

        private static string MaskSimple(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "";
            if (value.Length <= 2) return value;
            return value[0] + new string('*', value.Length - 2) + value[value.Length - 1];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
