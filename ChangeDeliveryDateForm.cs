using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class ChangeDeliveryDateForm : Form
    {
        private readonly int _orderId;

        public ChangeDeliveryDateForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            Load += ChangeDeliveryDateForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void ChangeDeliveryDateForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "SELECT OrderDeliveryDate FROM `Order` WHERE OrderID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _orderId);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                            dtpDelivery.Value = Convert.ToDateTime(res);
                        else
                            dtpDelivery.Value = DateTime.Now.AddDays(3);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки даты: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "UPDATE `Order` SET OrderDeliveryDate=@d WHERE OrderID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@d", dtpDelivery.Value);
                        cmd.Parameters.AddWithValue("@id", _orderId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Дата доставки обновлена.", "Успех",
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
