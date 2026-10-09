using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class DecorationOrderForm : Form
    {
        // Список добавленных в заказ товаров (Article, Name, Quantity)
        private readonly DataTable _cart;

        public DecorationOrderForm()
        {
            InitializeComponent();

            // Проверка прав: только менеджер может оформлять заказы
            if (GlobalConfig.UserRole != 2 || GlobalConfig.IsGuest)
            {
                MessageBox.Show("Оформление заказов доступно только менеджеру.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load += (s, e) => Close();
                return;
            }

            _cart = new DataTable();
            _cart.Columns.Add("ProductArticleNumber", typeof(string));
            _cart.Columns.Add("ProductName", typeof(string));
            _cart.Columns.Add("Quantity", typeof(int));

            dgvOrderProducts.DataSource = _cart;

            lblUser.Text = GlobalConfig.UserFIO;

            Load += DecorationOrderForm_Load;

            btnAddProduct.Click += BtnAddProduct_Click;
            btnRemoveProduct.Click += BtnRemoveProduct_Click;
            btnSave.Click += BtnSave_Click;
            btnBack.Click += (s, e) => Close();
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
        }

        // ------------------ Загрузка ------------------

        private void DecorationOrderForm_Load(object sender, EventArgs e)
        {
            LoadStatuses();
            LoadPickupPoints();
            LoadProducts();

            dtpOrderDate.Value = DateTime.Now;
            dtpOrderDeliveryDate.Value = DateTime.Now.AddDays(3);

            // Следующий код заказа = MAX(OrderCode)+1
            txtOrderCode.Text = GetNextOrderCode().ToString();
            txtOrderCode.ReadOnly = true;
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
                        cmbStatus.DataSource = dt;
                        cmbStatus.DisplayMember = "StatusName";
                        cmbStatus.ValueMember = "StatusID";
                        cmbStatus.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPickupPoints()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    // Учитываем реальную структуру: postal_code, city, street, house_number
                    string sql =
                        "SELECT PickupPointID, " +
                        "CONCAT_WS(', ', " +
                        "  NULLIF(postal_code, ''), " +
                        "  NULLIF(city, ''), " +
                        "  NULLIF(street, ''), " +
                        "  IFNULL(house_number, '')) AS Address " +
                        "FROM PickupPoint ORDER BY city, street";
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        cmbPickupPoint.DataSource = dt;
                        cmbPickupPoint.DisplayMember = "Address";
                        cmbPickupPoint.ValueMember = "PickupPointID";
                        cmbPickupPoint.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пунктов выдачи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var da = new MySqlDataAdapter(
                        "SELECT ProductArticleNumber, ProductName FROM Product ORDER BY ProductName", conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        cmbProduct.DataSource = dt;
                        cmbProduct.DisplayMember = "ProductName";
                        cmbProduct.ValueMember = "ProductArticleNumber";
                        cmbProduct.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ Кнопка «Добавить товар» ------------------

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем артикул выбранного товара рядом с комбобоксом
            if (cmbProduct.SelectedValue != null)
                lblArticleValue.Text = cmbProduct.SelectedValue.ToString();
            else
                lblArticleValue.Text = "—";
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите товар.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string article = cmbProduct.SelectedValue.ToString();
            string name = cmbProduct.Text;
            int qty = (int)nudQuantity.Value;

            // Если такой товар уже добавлен — увеличиваем количество
            foreach (DataRow row in _cart.Rows)
            {
                if (row["ProductArticleNumber"].ToString() == article)
                {
                    row["Quantity"] = (int)row["Quantity"] + qty;
                    return;
                }
            }

            _cart.Rows.Add(article, name, qty);
        }

        private void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvOrderProducts.CurrentRow == null) return;

            int index = dgvOrderProducts.CurrentRow.Index;
            _cart.Rows.RemoveAt(index);
        }

        // ------------------ Кнопка «Сохранить» ------------------

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string error))
            {
                MessageBox.Show(error, "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            int orderId = GetNextOrderId(conn, tran);
                            int orderCode = GetNextOrderCode();

                            string insertOrder =
                                "INSERT INTO `Order` " +
                                "(OrderID, OrderStatusID, OrderDate, OrderDeliveryDate, " +
                                " OrderPickupPointID, OrderClientName, OrderCode) " +
                                "VALUES (@id, @st, @dt, @dl, @pp, @cl, @code)";

                            using (var cmd = new MySqlCommand(insertOrder, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@id", orderId);
                                cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedValue);
                                cmd.Parameters.AddWithValue("@dt", dtpOrderDate.Value);
                                cmd.Parameters.AddWithValue("@dl", dtpOrderDeliveryDate.Value);
                                cmd.Parameters.AddWithValue("@pp", cmbPickupPoint.SelectedValue);
                                cmd.Parameters.AddWithValue("@cl", txtClientName.Text.Trim());
                                cmd.Parameters.AddWithValue("@code", orderCode);
                                cmd.ExecuteNonQuery();
                            }

                            string insertProduct =
                                "INSERT INTO OrderProduct " +
                                "(OrderID, ProductArticleNumber, Quantity) " +
                                "VALUES (@id, @a, @q)";

                            foreach (DataRow row in _cart.Rows)
                            {
                                using (var cmd = new MySqlCommand(insertProduct, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@id", orderId);
                                    cmd.Parameters.AddWithValue("@a", row["ProductArticleNumber"]);
                                    cmd.Parameters.AddWithValue("@q", row["Quantity"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Заказ успешно оформлен.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ Вспомогательные ------------------

        private static int GetNextOrderId(MySqlConnection conn, MySqlTransaction tran)
        {
            using (var cmd = new MySqlCommand(
                "SELECT IFNULL(MAX(OrderID), 0) + 1 FROM `Order`", conn, tran))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetNextOrderCode()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "SELECT IFNULL(MAX(OrderCode), 0) + 1 FROM `Order`", conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 1;
            }
        }

        private bool ValidateInput(out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                error = "Укажите ФИО клиента.";
                return false;
            }

            if (cmbStatus.SelectedValue == null)
            {
                error = "Выберите статус заказа.";
                return false;
            }

            if (cmbPickupPoint.SelectedValue == null)
            {
                error = "Выберите пункт выдачи.";
                return false;
            }

            if (dtpOrderDeliveryDate.Value < dtpOrderDate.Value)
            {
                error = "Дата выдачи не может быть раньше даты заказа.";
                return false;
            }

            if (_cart.Rows.Count == 0)
            {
                error = "Добавьте хотя бы один товар в заказ.";
                return false;
            }

            return true;
        }
    }
}