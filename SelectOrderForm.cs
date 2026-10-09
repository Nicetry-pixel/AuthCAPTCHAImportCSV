using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class SelectOrderForm : Form
    {
        public SelectOrderForm()
        {
            InitializeComponent();
            Load += SelectOrderForm_Load;
            btnBack.Click += (s, e) => Close();
        }

        private void SelectOrderForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = GlobalConfig.UserFIO;
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql =
                        "SELECT o.`OrderID`, " +
                        "       s.`StatusName`, " +
                        "       o.`OrderDate`, " +
                        "       o.`OrderDeliveryDate`, " +
                        "       CONCAT(' ', " +
                        "              IFNULL(p.`postal_code`, ''), ', ', " +
                        "              IFNULL(p.`city`, ''), ', ', " +
                        "              IFNULL(p.`street`, ''), ', д. ', " +
                        "              IFNULL(p.`house_number`, '')) AS PickupAddress, " +
                        "       o.`OrderClientName`, " +
                        "       o.`OrderCode` " +
                        "FROM `Order` o " +
                        "LEFT JOIN `OrderStatus` s ON s.`StatusID` = o.`OrderStatusID` " +
                        "LEFT JOIN `PickupPoint` p ON p.`PickupPointID` = o.`OrderPickupPointID` " +
                        "ORDER BY o.`OrderDate` DESC";

                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvOrders.DataSource = dt;
                        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}