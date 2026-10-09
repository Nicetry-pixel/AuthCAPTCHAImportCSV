using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class SelectProductForm : Form
    {
        private const int PageSize = 20;
        private int _page = 1;
        private int _totalRows = 0;
        private DataTable _allData;

        public SelectProductForm()
        {
            InitializeComponent();

            Load += SelectProductForm_Load;

            txtSearch.TextChanged += (s, e) => { _page = 1; ApplyFilters(); };
            cmbSort.SelectedIndexChanged += (s, e) => { _page = 1; ApplyFilters(); };
            cmbFilter.SelectedIndexChanged += (s, e) => { _page = 1; ApplyFilters(); };

            btnPrev.Click += (s, e) => { if (_page > 1) { _page--; ApplyFilters(); } };
            btnNext.Click += (s, e) => { if (_page * PageSize < _totalRows) { _page++; ApplyFilters(); } };
            btnBack.Click += (s, e) => Close();

            miAdd.Click += (s, e) => OpenEdit(null);
            miEdit.Click += (s, e) => OpenEdit(GetSelectedArticle());

            bool canEdit = (GlobalConfig.UserRole == 2) && !GlobalConfig.IsGuest;

            miAdd.Visible = canEdit;
            miEdit.Visible = canEdit;
            dgvProducts.ContextMenuStrip = canEdit ? contextMenuStrip1 : null;

            dgvProducts.CellFormatting += DgvProducts_CellFormatting;
            dgvProducts.CellPainting += DgvProducts_CellPainting;
            dgvProducts.CellMouseDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) return;
                if (GlobalConfig.UserRole != 2 || GlobalConfig.IsGuest) return;
                OpenEdit(GetSelectedArticle());
            };

            lblUser.Text = GlobalConfig.UserFIO;
        }

        private void SelectProductForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new object[] { "Без сортировки", "Цена ↑", "Цена ↓" });
            cmbSort.SelectedIndex = 0;

            cmbFilter.Items.AddRange(new object[]
            {
                "Все диапазоны", "0–9,99%", "10–14,99%", "15% и более"
            });
            cmbFilter.SelectedIndex = 0;

            LoadAll();
        }

        private void LoadAll()
        {
            try
            {
                using (var conn = new MySqlConnection(GlobalConfig.ConnectionString))
                {
                    conn.Open();
                    string sql =
                        "SELECT p.ProductArticleNumber, p.ProductName, p.ProductDescription, " +
                        "       p.ProductCost, p.ProductCurrentDiscount, p.ProductPhoto, " +
                        "       m.ManufacturerName " +
                        "FROM Product p " +
                        "LEFT JOIN Manufacturer m ON m.ManufacturerID = p.ManufacturerID";
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
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (_allData == null) return;

            var view = _allData.DefaultView;

            string search = txtSearch.Text.Trim().Replace("'", "''");
            string searchExpr = string.IsNullOrEmpty(search)
                ? ""
                : $"ProductName LIKE '%{search}%'";

            string filter = cmbFilter.SelectedItem?.ToString() ?? "Все диапазоны";
            string filterExpr = "";
            switch (filter)
            {
                case "0–9,99%":
                    filterExpr = "ProductCurrentDiscount >= 0 AND ProductCurrentDiscount < 10";
                    break;
                case "10–14,99%":
                    filterExpr = "ProductCurrentDiscount >= 10 AND ProductCurrentDiscount < 15";
                    break;
                case "15% и более":
                    filterExpr = "ProductCurrentDiscount >= 15";
                    break;
            }

            string combined = "";
            if (!string.IsNullOrEmpty(searchExpr) && !string.IsNullOrEmpty(filterExpr))
                combined = $"({searchExpr}) AND ({filterExpr})";
            else if (!string.IsNullOrEmpty(searchExpr))
                combined = searchExpr;
            else if (!string.IsNullOrEmpty(filterExpr))
                combined = filterExpr;

            view.RowFilter = combined;

            string sort = cmbSort.SelectedItem?.ToString() ?? "Без сортировки";
            if (sort == "Цена ↑") view.Sort = "ProductCost ASC";
            else if (sort == "Цена ↓") view.Sort = "ProductCost DESC";
            else view.Sort = "";

            _totalRows = view.Count;
            int totalPages = Math.Max(1, (int)Math.Ceiling(_totalRows / (double)PageSize));
            if (_page > totalPages) _page = totalPages;
            if (_page < 1) _page = 1;

            var pageTable = view.ToTable().Clone();
            for (int i = (_page - 1) * PageSize; i < Math.Min(_page * PageSize, _totalRows); i++)
                pageTable.ImportRow(view[i].Row);

            dgvProducts.DataSource = pageTable;
            ConfigureColumns();

            lblCount.Text = $"{pageTable.Rows.Count} из {_totalRows}";
            lblPage.Text = $"Страница {_page} из {totalPages}";
        }

        private void ConfigureColumns()
        {
            if (dgvProducts.Columns.Contains("colPhoto"))
                dgvProducts.Columns.Remove("colPhoto");

            var imgCol = new DataGridViewImageColumn
            {
                Name = "colPhoto",
                HeaderText = "Фото",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            };
            dgvProducts.Columns.Insert(0, imgCol);

            if (dgvProducts.Columns.Contains("ProductArticleNumber"))
                dgvProducts.Columns["ProductArticleNumber"].HeaderText = "Артикул";
            if (dgvProducts.Columns.Contains("ProductName"))
                dgvProducts.Columns["ProductName"].HeaderText = "Наименование";
            if (dgvProducts.Columns.Contains("ProductDescription"))
                dgvProducts.Columns["ProductDescription"].HeaderText = "Описание";
            if (dgvProducts.Columns.Contains("ManufacturerName"))
                dgvProducts.Columns["ManufacturerName"].HeaderText = "Производитель";
            if (dgvProducts.Columns.Contains("ProductCost"))
                dgvProducts.Columns["ProductCost"].HeaderText = "Цена";
            if (dgvProducts.Columns.Contains("ProductCurrentDiscount"))
                dgvProducts.Columns["ProductCurrentDiscount"].HeaderText = "Скидка, %";
            if (dgvProducts.Columns.Contains("ProductPhoto"))
                dgvProducts.Columns["ProductPhoto"].Visible = false;

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;
                string file = row.Cells["ProductPhoto"].Value?.ToString();
                row.Cells["colPhoto"].Value = LoadImageOrDefault(file);
            }
        }

        private Image LoadImageOrDefault(string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return Properties.Resources.Placeholder;

                string path = Path.Combine(Application.StartupPath, "Images", fileName);
                if (!File.Exists(path))
                    return Properties.Resources.Placeholder;

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    return Image.FromStream(fs);
            }
            catch { return Properties.Resources.Placeholder; }
        }

        private void DgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count) return;
            var row = dgvProducts.Rows[e.RowIndex];

            int discount = 0;
            int.TryParse(row.Cells["ProductCurrentDiscount"].Value?.ToString(), out discount);

            row.DefaultCellStyle.BackColor = discount >= 15
                ? Color.FromArgb(127, 255, 0)
                : Color.White;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "ProductCost" && discount > 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(102, 255, 102);
                e.CellStyle.ForeColor = Color.Black;

                decimal oldPrice = Convert.ToDecimal(row.Cells["ProductCost"].Value);
                decimal newPrice = oldPrice * (100 - discount) / 100m;

                e.Value = "";
            }
        }

        private void DgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvProducts.Columns[e.ColumnIndex].Name != "ProductCost") return;

            var row = dgvProducts.Rows[e.RowIndex];
            int discount = 0;
            int.TryParse(row.Cells["ProductCurrentDiscount"].Value?.ToString(), out discount);

            // Если скидки нет — обычная отрисовка
            if (discount <= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                TextRenderer.DrawText(e.Graphics,
                    row.Cells["ProductCost"].Value?.ToString(),
                    e.CellStyle.Font,
                    e.CellBounds,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                e.Handled = true;
                return;
            }

            decimal oldPrice = Convert.ToDecimal(row.Cells["ProductCost"].Value);
            decimal newPrice = oldPrice * (100 - discount) / 100m;

            // Фон + рамка ячейки
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            var g = e.Graphics;
            var oldFont = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            var newFont = new Font(e.CellStyle.Font, FontStyle.Bold);

            string oldText = $"{oldPrice:0.00} → ";
            string newText = $"{newPrice:0.00} (скидка {discount}%)";

            Size oldSize = TextRenderer.MeasureText(g, oldText, oldFont);
            Size newSize = TextRenderer.MeasureText(g, newText, newFont);

            int totalWidth = oldSize.Width + newSize.Width;
            int startX = e.CellBounds.Left + Math.Max(0, (e.CellBounds.Width - totalWidth) / 2);
            int y = e.CellBounds.Top + Math.Max(0, (e.CellBounds.Height - oldSize.Height) / 2);

            TextRenderer.DrawText(g, oldText, oldFont,
                new Point(startX, y), Color.Black,
                TextFormatFlags.NoPadding);

            TextRenderer.DrawText(g, newText, newFont,
                new Point(startX + oldSize.Width, y), Color.Black,
                TextFormatFlags.NoPadding);

            e.Handled = true;
        }

        private string GetSelectedArticle()
        {
            if (dgvProducts.CurrentRow == null) return null;
            return dgvProducts.CurrentRow.Cells["ProductArticleNumber"].Value?.ToString();
        }

        private void OpenEdit(string article)
        {
            bool canEdit = GlobalConfig.UserRole == 2 && !GlobalConfig.IsGuest;
            if (!canEdit)
            {
                MessageBox.Show("Клиент не может редактировать товары.", "Доступ запрещён",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var f = new ProductEditForm(article))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadAll();
            }
        }
    }
}
