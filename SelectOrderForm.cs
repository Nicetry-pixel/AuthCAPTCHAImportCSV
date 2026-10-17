using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class SelectOrderForm : Form
    {
        private bool _showPersonalData = false;
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
        private void ChkShowPersonalData_CheckedChanged(object sender, EventArgs e)
        {
            //_showPersonalData = chkShowPersonalData.Checked;
            MaskPersonalData();
        }
        private void MaskPersonalData()
        {
            if (dgvOrders == null || dgvOrders.Rows.Count == 0) return;
            if (!dgvOrders.Columns.Contains("OrderClientName")) return;

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;

                // Берём исходное значение из DataBoundItem, а не из ячейки —
                // иначе второй вызов замаскирует уже замаскированное
                var bound = row.DataBoundItem as System.Data.DataRowView;
                string original = bound != null
                    ? bound["OrderClientName"]?.ToString() ?? ""
                    : row.Cells["OrderClientName"].Value?.ToString() ?? "";

                row.Cells["OrderClientName"].Value = _showPersonalData
                    ? original
                    : PersonalDataProtector.MaskFIO(original);
            }
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;

                // Берём исходное значение из DataBoundItem, а не из ячейки —
                // иначе второй вызов замаскирует уже замаскированное
                var bound = row.DataBoundItem as System.Data.DataRowView;
                string original = bound != null
                    ? bound["PickupAddress"]?.ToString() ?? ""
                    : row.Cells["PickupAddress"].Value?.ToString() ?? "";

                row.Cells["PickupAddress"].Value = _showPersonalData
                    ? original
                    : PersonalDataProtector.MaskAddress(original);
            }
        }
        private void LoadOrders()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql =
                        "SELECT " +
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
                        MaskPersonalData();
                        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ConfigureColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureColumns()
        {
            if (dgvOrders.Columns.Contains("StatusName"))
                dgvOrders.Columns["StatusName"].HeaderText = "Статус";
            if (dgvOrders.Columns.Contains("OrderDate"))
                dgvOrders.Columns["OrderDate"].HeaderText = "Дата создания";
            if (dgvOrders.Columns.Contains("OrderDeliveryDate"))
                dgvOrders.Columns["OrderDeliveryDate"].HeaderText = "Дата доставки";
            if (dgvOrders.Columns.Contains("PickupAddress"))
                dgvOrders.Columns["PickupAddress"].HeaderText = "Адрес";
            if (dgvOrders.Columns.Contains("OrderClientName"))
                dgvOrders.Columns["OrderClientName"].HeaderText = "ФИО Клиента";
            if (dgvOrders.Columns.Contains("OrderCode"))
                dgvOrders.Columns["OrderCode"].HeaderText = "Код заказа";
        }
    }
}