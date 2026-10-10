using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class OrderProcessingForm : Form
    {
        private const int PageSize = 20;

        private int _page = 1;
        private int _totalRows = 0;
        private DataTable _allData;

        public OrderProcessingForm()
        {
            InitializeComponent();

            // Доступ только менеджеру и администратору
            if (GlobalConfig.UserRole != 1 && GlobalConfig.UserRole != 2)
            {
                MessageBox.Show("Управление заказами доступно менеджеру и администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load += (s, e) => Close();
                return;
            }

            Load += OrderProcessingForm_Load;

            txtSearch.TextChanged += (s, e) => { _page = 1; ApplyFilters(); };
            cmbSort.SelectedIndexChanged += (s, e) => { _page = 1; ApplyFilters(); };
            cmbStatusFilter.SelectedIndexChanged += (s, e) => { _page = 1; ApplyFilters(); };
            dtpFrom.ValueChanged += (s, e) => { _page = 1; ApplyFilters(); };
            dtpTo.ValueChanged += (s, e) => { _page = 1; ApplyFilters(); };

            btnPrev.Click += (s, e) => { if (_page > 1) { _page--; ApplyFilters(); } };
            btnNext.Click += (s, e) => { if (_page * PageSize < _totalRows) { _page++; ApplyFilters(); } };
            btnBack.Click += (s, e) => Close();

            miViewDetails.Click += (s, e) => ViewDetails();
            miChangeStatus.Click += (s, e) => ChangeStatus();
            miChangeDelivery.Click += (s, e) => ChangeDeliveryDate();

            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            dgvOrders.CellMouseDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) ViewDetails();
            };
        }

        private void OrderProcessingForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = GlobalConfig.UserFIO;

            cmbSort.Items.AddRange(new object[]
            {
                "Без сортировки",
                "Сумма ↑",
                "Сумма ↓",
                "Дата заказа ↑",
                "Дата заказа ↓"
            });
            cmbSort.SelectedIndex = 0;

            cmbStatusFilter.Items.Add("Все статусы");
            LoadStatuses();
            cmbStatusFilter.SelectedIndex = 0;

            dtpFrom.Value = DateTime.Today.AddMonths(-3);
            dtpTo.Value = DateTime.Today.AddMonths(1);

            LoadAllOrders();
        }

        private void LoadStatuses()
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
                        foreach (DataRow row in dt.Rows)
                            cmbStatusFilter.Items.Add(row["StatusName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка всех заказов с суммой, скидкой и признаком наличия товаров на складе
        private void LoadAllOrders()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT o.`OrderID`,
                               o.`OrderCode`,
                               o.`OrderClientName`,
                               o.`OrderDate`,
                               o.`OrderDeliveryDate`,
                               s.`StatusName`,
                               CONCAT_WS(', ',
                                   NULLIF(p.`postal_code`, ''),
                                   NULLIF(p.`city`, ''),
                                   NULLIF(p.`street`, ''),
                                   IFNULL(p.`house_number`, '')) AS PickupAddress,

                               IFNULL((SELECT SUM(op.`Quantity` * pr.`ProductCost`)
                                       FROM OrderProduct op
                                       JOIN Product pr ON pr.`ProductArticleNumber` = op.`ProductArticleNumber`
                                       WHERE op.`OrderID` = o.`OrderID`), 0) AS TotalSum,

                               IFNULL((SELECT SUM(op.`Quantity` * pr.`ProductCost`
                                                  * pr.`ProductCurrentDiscount` / 100)
                                       FROM OrderProduct op
                                       JOIN Product pr ON pr.`ProductArticleNumber` = op.`ProductArticleNumber`
                                       WHERE op.`OrderID` = o.`OrderID`), 0) AS DiscountSum,

                               (SELECT COUNT(*)
                                  FROM OrderProduct op2
                                  JOIN Product pr2 ON pr2.`ProductArticleNumber` = op2.`ProductArticleNumber`
                                 WHERE op2.`OrderID` = o.`OrderID`) AS PositionsCount,

                               (SELECT COUNT(*)
                                  FROM OrderProduct op3
                                  JOIN Product pr3 ON pr3.`ProductArticleNumber` = op3.`ProductArticleNumber`
                                 WHERE op3.`OrderID` = o.`OrderID`
                                   AND (pr3.`ProductQuantityInStock` IS NULL
                                        OR pr3.`ProductQuantityInStock` < op3.`Quantity`)) AS MissingPositions

                        FROM `Order` o
                        LEFT JOIN `OrderStatus` s ON s.`StatusID` = o.`OrderStatusID`
                        LEFT JOIN `PickupPoint` p ON p.`PickupPointID` = o.`OrderPickupPointID`
                        ORDER BY o.`OrderDate` DESC";

                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        _allData = new DataTable();
                        da.Fill(_allData);
                    }
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (_allData == null) return;

            var view = _allData.DefaultView;

            // Поиск по ФИО клиента
            string search = txtSearch.Text.Trim().Replace("'", "''");
            string searchExpr = string.IsNullOrEmpty(search)
                ? ""
                : $"OrderClientName LIKE '%{search}%'";

            // Фильтр по статусу
            string statusExpr = "";
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                string status = cmbStatusFilter.SelectedItem.ToString().Replace("'", "''");
                statusExpr = $"StatusName = '{status}'";
            }

            // Фильтр по дате
            string dateExpr = $"OrderDate >= #{dtpFrom.Value:yyyy-MM-dd}# AND OrderDate <= #{dtpTo.Value:yyyy-MM-dd 23:59:59}#";

            string combined = CombineExpr(CombineExpr(searchExpr, statusExpr), dateExpr);
            view.RowFilter = combined;

            // Сортировка
            string sort = cmbSort.SelectedItem?.ToString() ?? "Без сортировки";
            switch (sort)
            {
                case "Сумма ↑": view.Sort = "TotalSum ASC"; break;
                case "Сумма ↓": view.Sort = "TotalSum DESC"; break;
                case "Дата заказа ↑": view.Sort = "OrderDate ASC"; break;
                case "Дата заказа ↓": view.Sort = "OrderDate DESC"; break;
                default: view.Sort = ""; break;
            }

            _totalRows = view.Count;
            int totalPages = Math.Max(1, (int)Math.Ceiling(_totalRows / (double)PageSize));
            if (_page > totalPages) _page = totalPages;
            if (_page < 1) _page = 1;

            var pageTable = view.ToTable().Clone();
            for (int i = (_page - 1) * PageSize; i < Math.Min(_page * PageSize, _totalRows); i++)
                pageTable.ImportRow(view[i].Row);

            dgvOrders.DataSource = pageTable;
            ConfigureColumns();

            lblCount.Text = $"{pageTable.Rows.Count} из {_totalRows}";
            lblPage.Text = $"Страница {_page} из {totalPages}";
        }

        private static string CombineExpr(string a, string b)
        {
            bool hasA = !string.IsNullOrEmpty(a);
            bool hasB = !string.IsNullOrEmpty(b);
            if (hasA && hasB) return $"({a}) AND ({b})";
            if (hasA) return a;
            if (hasB) return b;
            return "";
        }

        private void ConfigureColumns()
        {
            if (dgvOrders.Columns.Contains("OrderID"))
                dgvOrders.Columns["OrderID"].HeaderText = "№ заказа";
            if (dgvOrders.Columns.Contains("OrderCode"))
                dgvOrders.Columns["OrderCode"].HeaderText = "Код";
            if (dgvOrders.Columns.Contains("OrderClientName"))
                dgvOrders.Columns["OrderClientName"].HeaderText = "ФИО клиента";
            if (dgvOrders.Columns.Contains("OrderDate"))
                dgvOrders.Columns["OrderDate"].HeaderText = "Дата заказа";
            if (dgvOrders.Columns.Contains("OrderDeliveryDate"))
                dgvOrders.Columns["OrderDeliveryDate"].HeaderText = "Дата доставки";
            if (dgvOrders.Columns.Contains("StatusName"))
                dgvOrders.Columns["StatusName"].HeaderText = "Статус";
            if (dgvOrders.Columns.Contains("PickupAddress"))
                dgvOrders.Columns["PickupAddress"].HeaderText = "Пункт выдачи";
            if (dgvOrders.Columns.Contains("TotalSum"))
            {
                dgvOrders.Columns["TotalSum"].HeaderText = "Сумма заказа, руб.";
                dgvOrders.Columns["TotalSum"].DefaultCellStyle.Format = "0.00";
            }
            if (dgvOrders.Columns.Contains("DiscountSum"))
            {
                dgvOrders.Columns["DiscountSum"].HeaderText = "Скидка, руб.";
                dgvOrders.Columns["DiscountSum"].DefaultCellStyle.Format = "0.00";
            }
            if (dgvOrders.Columns.Contains("PositionsCount"))
                dgvOrders.Columns["PositionsCount"].Visible = false;
            if (dgvOrders.Columns.Contains("MissingPositions"))
                dgvOrders.Columns["MissingPositions"].Visible = false;

            if (dgvOrders.Columns.Contains("OrderDate"))
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            if (dgvOrders.Columns.Contains("OrderDeliveryDate"))
                dgvOrders.Columns["OrderDeliveryDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        // Подсветка строк: зелёный — всё на складе (>3 позиции), оранжевый — есть отсутствующие
        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvOrders.Rows.Count) return;

            var row = dgvOrders.Rows[e.RowIndex];
            int missing = 0;
            int positions = 0;
            int.TryParse(row.Cells["MissingPositions"].Value?.ToString(), out missing);
            int.TryParse(row.Cells["PositionsCount"].Value?.ToString(), out positions);

            if (missing > 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0x8C, 0x00); // #FF8C00
            }
            else if (positions > 3)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(0x20, 0xB2, 0xAA); // #20B2AA
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private int? GetSelectedOrderId()
        {
            if (dgvOrders.CurrentRow == null) return null;
            int id;
            if (int.TryParse(dgvOrders.CurrentRow.Cells["OrderID"].Value?.ToString(), out id))
                return id;
            return null;
        }

        // ------------------ Контекстное меню ------------------

        private void ViewDetails()
        {
            int? id = GetSelectedOrderId();
            if (!id.HasValue) return;

            using (var f = new OrderDetailsForm(id.Value))
            {
                f.ShowDialog();
                LoadAllOrders();
            }
        }

        private void ChangeStatus()
        {
            int? id = GetSelectedOrderId();
            if (!id.HasValue) return;

            using (var f = new ChangeOrderStatusForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadAllOrders();
            }
        }

        private void ChangeDeliveryDate()
        {
            int? id = GetSelectedOrderId();
            if (!id.HasValue) return;

            using (var f = new ChangeDeliveryDateForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadAllOrders();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var text = txtSearch.Text;
            var allowedChars = new System.Text.StringBuilder();
            bool hadInvalid = false;

            foreach (char c in text)
            {
                if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё')
                {
                    allowedChars.Append(c);
                }
                else
                {
                    hadInvalid = true;
                }
            }

            if (hadInvalid)
            {
                MessageBox.Show("Разрешены только русские буквы (А-я, а-я, Ё,ё).",
                    "Некорректный ввод",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            if (allowedChars.Length < text.Length)
            {
                txtSearch.Text = allowedChars.ToString();
                txtSearch.SelectionStart = txtSearch.Text.Length;
            }
        }
    }
}
