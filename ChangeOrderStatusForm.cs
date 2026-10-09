using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class ChangeOrderStatusForm : Form
    {
        private readonly int _orderId;

        public ChangeOrderStatusForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            Load += ChangeOrderStatusForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void ChangeOrderStatusForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();

                    using (var da = new MySqlDataAdapter(
                        "SELECT StatusID, StatusName FROM OrderStatus ORDER BY StatusName", conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        cmbStatus.DataSource = dt;
                        cmbStatus.DisplayMember = "StatusName";
                        cmbStatus.ValueMember = "StatusID";
                    }

                    using (var cmd = new MySqlCommand(
                        "SELECT OrderStatusID FROM `Order` WHERE OrderID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _orderId);
                        object res = cmd.ExecuteScalar();
                        if (res != null)
                            cmbStatus.SelectedValue = Convert.ToInt32(res);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedValue == null) return;
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "UPDATE `Order` SET OrderStatusID=@st WHERE OrderID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", _orderId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Статус заказа обновлён.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
