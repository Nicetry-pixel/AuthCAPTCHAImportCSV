using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class ProductEditForm : Form
    {
        private readonly string _article;
        private readonly bool _isEdit;

        public ProductEditForm(string article = null)
        {
            InitializeComponent();
            _article = article;
            _isEdit = !string.IsNullOrEmpty(article);
            Text = _isEdit ? "Редактирование товара" : "Добавление товара";

            Load += ProductEditForm_Load;
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            if (_isEdit) LoadProduct();
        }

        private void LoadCombos()
        {
            using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                conn.Open();
                FillCombo(cmbCategory, "SELECT CategoryID, CategoryName FROM Category", "CategoryID", "CategoryName", conn);
                FillCombo(cmbManufacturer, "SELECT ManufacturerID, ManufacturerName FROM Manufacturer", "ManufacturerID", "ManufacturerName", conn);
                FillCombo(cmbSupplier, "SELECT SupplierID, SupplierName FROM Supplier", "SupplierID", "SupplierName", conn);
                FillCombo(cmbUnit, "SELECT UnitID, UnitName FROM Unit", "UnitID", "UnitName", conn);
                FillCombo(cmbStatus, "SELECT ProductStatusID, ProductStatusName FROM ProductStatus", "ProductStatusID", "ProductStatusName", conn);
            }
        }

        private static void FillCombo(ComboBox cmb, string sql, string val, string disp, MySqlConnection conn)
        {
            using (var da = new MySqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmb.DataSource = dt;
                cmb.DisplayMember = disp;
                cmb.ValueMember = val;
                cmb.SelectedIndex = -1;
            }
        }

        private void LoadProduct()
        {
            using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT ProductName, ProductDescription, CategoryID, ManufacturerID, SupplierID, " +
                    "UnitID, ProductCost, ProductMaxDiscount, ProductCurrentDiscount, " +
                    "ProductQuantityInStock, ProductStatusID, ProductPhoto FROM Product " +
                    "WHERE ProductArticleNumber=@a", conn))
                {
                    cmd.Parameters.AddWithValue("@a", _article);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        txtArticle.Text = _article;
                        txtName.Text = r.GetString(0);
                        txtDescription.Text = r.GetString(1);
                        cmbCategory.SelectedValue = r.GetInt32(2);
                        cmbManufacturer.SelectedValue = r.GetInt32(3);
                        cmbSupplier.SelectedValue = r.GetInt32(4);
                        cmbUnit.SelectedValue = r.GetInt32(5);
                        txtCost.Text = r.GetDecimal(6).ToString("0.00");
                        txtMaxDiscount.Text = r.IsDBNull(7) ? "" : r.GetByte(7).ToString();
                        txtCurDiscount.Text = r.IsDBNull(8) ? "" : r.GetByte(8).ToString();
                        txtQuantity.Text = r.GetInt32(9).ToString();
                        cmbStatus.SelectedValue = r.GetInt32(10);
                        txtPhoto.Text = r.IsDBNull(11) ? "" : r.GetString(11);
                    }
                }
            }
            txtArticle.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                    if (!_isEdit)
                    {
                        using (var chk = new MySqlCommand(
                            "SELECT COUNT(*) FROM Product WHERE ProductArticleNumber=@a", conn))
                        {
                            chk.Parameters.AddWithValue("@a", txtArticle.Text.Trim());
                            if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("Товар с таким артикулом уже существует.",
                                    "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    string sql = _isEdit
                        ? "UPDATE Product SET ProductName=@n, ProductDescription=@d, CategoryID=@c, " +
                          "ManufacturerID=@m, SupplierID=@s, UnitID=@u, ProductCost=@cost, " +
                          "ProductMaxDiscount=@md, ProductCurrentDiscount=@cd, " +
                          "ProductQuantityInStock=@q, ProductStatusID=@st, ProductPhoto=@ph " +
                          "WHERE ProductArticleNumber=@a"
                        : "INSERT INTO Product (ProductArticleNumber, ProductName, ProductDescription, " +
                          "CategoryID, ManufacturerID, SupplierID, UnitID, ProductCost, " +
                          "ProductMaxDiscount, ProductCurrentDiscount, ProductQuantityInStock, " +
                          "ProductStatusID, ProductPhoto) " +
                          "VALUES (@a,@n,@d,@c,@m,@s,@u,@cost,@md,@cd,@q,@st,@ph)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@a", txtArticle.Text.Trim());
                        cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@m", cmbManufacturer.SelectedValue);
                        cmd.Parameters.AddWithValue("@s", cmbSupplier.SelectedValue);
                        cmd.Parameters.AddWithValue("@u", cmbUnit.SelectedValue);
                        cmd.Parameters.AddWithValue("@cost", decimal.Parse(txtCost.Text));
                        cmd.Parameters.AddWithValue("@md", ParseNullableByte(txtMaxDiscount.Text));
                        cmd.Parameters.AddWithValue("@cd", ParseNullableByte(txtCurDiscount.Text));
                        cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                        cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@ph", string.IsNullOrWhiteSpace(txtPhoto.Text)
                            ? (object)DBNull.Value : txtPhoto.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static object ParseNullableByte(string s) =>
            string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : byte.Parse(s);

        private bool ValidateInput(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(txtArticle.Text)) { error = "Укажите артикул."; return false; }
            if (string.IsNullOrWhiteSpace(txtName.Text)) { error = "Укажите наименование."; return false; }
            if (cmbCategory.SelectedValue == null) { error = "Выберите категорию."; return false; }
            if (cmbManufacturer.SelectedValue == null) { error = "Выберите производителя."; return false; }
            if (cmbSupplier.SelectedValue == null) { error = "Выберите поставщика."; return false; }
            if (cmbUnit.SelectedValue == null) { error = "Выберите единицу измерения."; return false; }
            if (cmbStatus.SelectedValue == null) { error = "Выберите статус товара."; return false; }
            if (!decimal.TryParse(txtCost.Text, out _)) { error = "Некорректная цена."; return false; }
            if (!int.TryParse(txtQuantity.Text, out _)) { error = "Некорректное количество."; return false; }
            if (!string.IsNullOrWhiteSpace(txtMaxDiscount.Text) && !byte.TryParse(txtMaxDiscount.Text, out _)) { error = "Некорректная макс. скидка."; return false; }
            if (!string.IsNullOrWhiteSpace(txtCurDiscount.Text) && !byte.TryParse(txtCurDiscount.Text, out _)) { error = "Некорректная текущая скидка."; return false; }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}