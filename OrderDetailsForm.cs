using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class OrderDetailsForm : Form
    {
        private readonly int _orderId;

        public OrderDetailsForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            Load += OrderDetailsForm_Load;
            btnClose.Click += (s, e) => Close();
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            LoadOrderHeader();
            LoadOrderProducts();
        }

        private void LoadOrderHeader()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT o.`OrderID`, o.`OrderCode`, o.`OrderClientName`,
                               o.`OrderDate`, o.`OrderDeliveryDate`,
                               s.`StatusName`,
                               CONCAT_WS(', ',
                                   NULLIF(p.`postal_code`, ''),
                                   NULLIF(p.`city`, ''),
                                   NULLIF(p.`street`, ''),
                                   IFNULL(p.`house_number`, '')) AS PickupAddress
                        FROM `Order` o
                        LEFT JOIN `OrderStatus` s ON s.`StatusID` = o.`OrderStatusID`
                        LEFT JOIN `PickupPoint` p ON p.`PickupPointID` = o.`OrderPickupPointID`
                        WHERE o.`OrderID` = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _orderId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return;
                            lblOrderId.Text = $"№ заказа: {r["OrderID"]}";
                            lblOrderCode.Text = $"Код: {r["OrderCode"]}";
                            lblClient.Text = $"ФИО клиента: {r["OrderClientName"]}";
                            lblOrderDate.Text = $"Дата заказа: {Convert.ToDateTime(r["OrderDate"]):dd.MM.yyyy}";
                            lblDeliveryDate.Text = $"Дата доставки: {Convert.ToDateTime(r["OrderDeliveryDate"]):dd.MM.yyyy}";
                            lblStatus.Text = $"Статус: {r["StatusName"]}";
                            lblPickupAddress.Text = $"Пункт выдачи: {r["PickupAddress"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderProducts()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT op.`ProductArticleNumber` AS Артикул,
                               pr.`ProductName`          AS Наименование,
                               op.`Quantity`             AS Количество,
                               pr.`ProductCost`          AS Цена,
                               (op.`Quantity` * pr.`ProductCost`) AS Сумма
                        FROM OrderProduct op
                        JOIN Product pr ON pr.`ProductArticleNumber` = op.`ProductArticleNumber`
                        WHERE op.`OrderID` = @id";

                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        cmd_set_id(da);
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvProducts.DataSource = dt;
                        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки состава заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_set_id(MySqlDataAdapter da)
        {
            da.SelectCommand.Parameters.AddWithValue("@id", _orderId);
        }
    }
}
