namespace AuthCAPTCHAImportCSV
{
    partial class DecorationOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Panel contentPanel;

        // Левая колонка — данные заказа
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPickupPoint;
        private System.Windows.Forms.ComboBox cmbPickupPoint;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDeliveryDate;

        // Правая колонка — товары
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label lblArticleValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.DataGridView dgvOrderProducts;

        // Нижняя панель
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblPickupPoint = new System.Windows.Forms.Label();
            this.cmbPickupPoint = new System.Windows.Forms.ComboBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpOrderDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblArticle = new System.Windows.Forms.Label();
            this.lblArticleValue = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.dgvOrderProducts = new System.Windows.Forms.DataGridView();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.lblUser);
            this.headerPanel.Controls.Add(this.btnBack);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(900, 90);
            this.headerPanel.TabIndex = 2;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::AuthCAPTCHAImportCSV.Properties.Resources.logo;
            this.logoPictureBox.Location = new System.Drawing.Point(357, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(70, 70);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(100, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(251, 35);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Оформление заказа";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(624, 33);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "ФИО";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnBack.Location = new System.Drawing.Point(15, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 40);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.contentPanel.Controls.Add(this.lblClientName);
            this.contentPanel.Controls.Add(this.txtClientName);
            this.contentPanel.Controls.Add(this.lblOrderCode);
            this.contentPanel.Controls.Add(this.txtOrderCode);
            this.contentPanel.Controls.Add(this.lblStatus);
            this.contentPanel.Controls.Add(this.cmbStatus);
            this.contentPanel.Controls.Add(this.lblPickupPoint);
            this.contentPanel.Controls.Add(this.cmbPickupPoint);
            this.contentPanel.Controls.Add(this.lblOrderDate);
            this.contentPanel.Controls.Add(this.dtpOrderDate);
            this.contentPanel.Controls.Add(this.lblDeliveryDate);
            this.contentPanel.Controls.Add(this.dtpOrderDeliveryDate);
            this.contentPanel.Controls.Add(this.lblProduct);
            this.contentPanel.Controls.Add(this.cmbProduct);
            this.contentPanel.Controls.Add(this.lblArticle);
            this.contentPanel.Controls.Add(this.lblArticleValue);
            this.contentPanel.Controls.Add(this.lblQuantity);
            this.contentPanel.Controls.Add(this.nudQuantity);
            this.contentPanel.Controls.Add(this.btnAddProduct);
            this.contentPanel.Controls.Add(this.btnRemoveProduct);
            this.contentPanel.Controls.Add(this.dgvOrderProducts);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 90);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(900, 530);
            this.contentPanel.TabIndex = 0;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblClientName.Location = new System.Drawing.Point(20, 20);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(108, 20);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "ФИО клиента:";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtClientName.Location = new System.Drawing.Point(180, 17);
            this.txtClientName.MaxLength = 100;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(300, 28);
            this.txtClientName.TabIndex = 0;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblOrderCode.Location = new System.Drawing.Point(20, 58);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(90, 20);
            this.lblOrderCode.TabIndex = 1;
            this.lblOrderCode.Text = "Код заказа:";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtOrderCode.Location = new System.Drawing.Point(180, 55);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(120, 28);
            this.txtOrderCode.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblStatus.Location = new System.Drawing.Point(20, 96);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbStatus.Location = new System.Drawing.Point(180, 93);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 28);
            this.cmbStatus.TabIndex = 2;
            // 
            // lblPickupPoint
            // 
            this.lblPickupPoint.AutoSize = true;
            this.lblPickupPoint.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblPickupPoint.Location = new System.Drawing.Point(20, 134);
            this.lblPickupPoint.Name = "lblPickupPoint";
            this.lblPickupPoint.Size = new System.Drawing.Size(116, 20);
            this.lblPickupPoint.TabIndex = 3;
            this.lblPickupPoint.Text = "Пункт выдачи:";
            // 
            // cmbPickupPoint
            // 
            this.cmbPickupPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPickupPoint.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbPickupPoint.Location = new System.Drawing.Point(180, 131);
            this.cmbPickupPoint.Name = "cmbPickupPoint";
            this.cmbPickupPoint.Size = new System.Drawing.Size(300, 28);
            this.cmbPickupPoint.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblOrderDate.Location = new System.Drawing.Point(20, 172);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(97, 20);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Дата заказа:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(180, 169);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(300, 28);
            this.dtpOrderDate.TabIndex = 4;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblDeliveryDate.Location = new System.Drawing.Point(20, 210);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(107, 20);
            this.lblDeliveryDate.TabIndex = 5;
            this.lblDeliveryDate.Text = "Дата выдачи:";
            // 
            // dtpOrderDeliveryDate
            // 
            this.dtpOrderDeliveryDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.dtpOrderDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDeliveryDate.Location = new System.Drawing.Point(180, 207);
            this.dtpOrderDeliveryDate.Name = "dtpOrderDeliveryDate";
            this.dtpOrderDeliveryDate.Size = new System.Drawing.Size(300, 28);
            this.dtpOrderDeliveryDate.TabIndex = 5;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblProduct.Location = new System.Drawing.Point(510, 20);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 20);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Товар:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbProduct.Location = new System.Drawing.Point(610, 17);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(270, 28);
            this.cmbProduct.TabIndex = 6;
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblArticle.Location = new System.Drawing.Point(510, 58);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(74, 20);
            this.lblArticle.TabIndex = 7;
            this.lblArticle.Text = "Артикул:";
            // 
            // lblArticleValue
            // 
            this.lblArticleValue.AutoSize = true;
            this.lblArticleValue.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblArticleValue.Location = new System.Drawing.Point(610, 58);
            this.lblArticleValue.Name = "lblArticleValue";
            this.lblArticleValue.Size = new System.Drawing.Size(23, 21);
            this.lblArticleValue.TabIndex = 8;
            this.lblArticleValue.Text = "—";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblQuantity.Location = new System.Drawing.Point(510, 96);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 20);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Количество:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.nudQuantity.Location = new System.Drawing.Point(610, 93);
            this.nudQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(80, 28);
            this.nudQuantity.TabIndex = 7;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.Location = new System.Drawing.Point(700, 90);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(180, 33);
            this.btnAddProduct.TabIndex = 10;
            this.btnAddProduct.Text = "Добавить в заказ";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.White;
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnRemoveProduct.Location = new System.Drawing.Point(610, 135);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(270, 33);
            this.btnRemoveProduct.TabIndex = 11;
            this.btnRemoveProduct.Text = "Удалить выбранный товар";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            // 
            // dgvOrderProducts
            // 
            this.dgvOrderProducts.AllowUserToAddRows = false;
            this.dgvOrderProducts.AllowUserToDeleteRows = false;
            this.dgvOrderProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderProducts.Location = new System.Drawing.Point(20, 260);
            this.dgvOrderProducts.Name = "dgvOrderProducts";
            this.dgvOrderProducts.ReadOnly = true;
            this.dgvOrderProducts.RowHeadersVisible = false;
            this.dgvOrderProducts.Size = new System.Drawing.Size(860, 230);
            this.dgvOrderProducts.TabIndex = 8;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.White;
            this.bottomPanel.Controls.Add(this.btnSave);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 620);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(900, 60);
            this.bottomPanel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(350, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить заказ";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // DecorationOrderForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.MinimumSize = new System.Drawing.Size(900, 680);
            this.Name = "DecorationOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оформление заказа";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}