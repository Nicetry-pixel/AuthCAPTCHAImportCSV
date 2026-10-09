namespace AuthCAPTCHAImportCSV
{
    partial class ProductEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblMaxDiscount;
        private System.Windows.Forms.Label lblCurDiscount;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPhoto;

        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtMaxDiscount;
        private System.Windows.Forms.TextBox txtCurDiscount;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPhoto;

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditForm));
            this.lblArticle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblMaxDiscount = new System.Windows.Forms.Label();
            this.lblCurDiscount = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtMaxDiscount = new System.Windows.Forms.TextBox();
            this.txtCurDiscount = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblArticle.Location = new System.Drawing.Point(20, 20);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(74, 20);
            this.lblArticle.TabIndex = 0;
            this.lblArticle.Text = "Артикул:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblName.Location = new System.Drawing.Point(20, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(121, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Наименование:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblDescription.Location = new System.Drawing.Point(20, 96);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Описание:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblCategory.Location = new System.Drawing.Point(20, 175);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(88, 20);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Категория:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblManufacturer.Location = new System.Drawing.Point(20, 213);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(129, 20);
            this.lblManufacturer.TabIndex = 4;
            this.lblManufacturer.Text = "Производитель:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblSupplier.Location = new System.Drawing.Point(20, 251);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(96, 20);
            this.lblSupplier.TabIndex = 5;
            this.lblSupplier.Text = "Поставщик:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblUnit.Location = new System.Drawing.Point(20, 289);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(76, 20);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Единица:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblStatus.Location = new System.Drawing.Point(20, 327);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Статус:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblCost.Location = new System.Drawing.Point(20, 365);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(49, 20);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Цена:";
            // 
            // lblMaxDiscount
            // 
            this.lblMaxDiscount.AutoSize = true;
            this.lblMaxDiscount.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblMaxDiscount.Location = new System.Drawing.Point(20, 403);
            this.lblMaxDiscount.Name = "lblMaxDiscount";
            this.lblMaxDiscount.Size = new System.Drawing.Size(125, 20);
            this.lblMaxDiscount.TabIndex = 9;
            this.lblMaxDiscount.Text = "Макс. скидка, %:";
            // 
            // lblCurDiscount
            // 
            this.lblCurDiscount.AutoSize = true;
            this.lblCurDiscount.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblCurDiscount.Location = new System.Drawing.Point(20, 441);
            this.lblCurDiscount.Name = "lblCurDiscount";
            this.lblCurDiscount.Size = new System.Drawing.Size(147, 20);
            this.lblCurDiscount.TabIndex = 10;
            this.lblCurDiscount.Text = "Текущая скидка, %:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblQuantity.Location = new System.Drawing.Point(20, 479);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(139, 20);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Кол-во на складе:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblPhoto.Location = new System.Drawing.Point(20, 517);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(84, 20);
            this.lblPhoto.TabIndex = 12;
            this.lblPhoto.Text = "Имя фото:";
            // 
            // txtArticle
            // 
            this.txtArticle.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtArticle.Location = new System.Drawing.Point(200, 17);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(300, 28);
            this.txtArticle.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtName.Location = new System.Drawing.Point(200, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 28);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtDescription.Location = new System.Drawing.Point(200, 93);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 60);
            this.txtDescription.TabIndex = 2;
            // 
            // txtCost
            // 
            this.txtCost.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtCost.Location = new System.Drawing.Point(200, 362);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(150, 28);
            this.txtCost.TabIndex = 8;
            // 
            // txtMaxDiscount
            // 
            this.txtMaxDiscount.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtMaxDiscount.Location = new System.Drawing.Point(200, 400);
            this.txtMaxDiscount.Name = "txtMaxDiscount";
            this.txtMaxDiscount.Size = new System.Drawing.Size(150, 28);
            this.txtMaxDiscount.TabIndex = 9;
            // 
            // txtCurDiscount
            // 
            this.txtCurDiscount.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtCurDiscount.Location = new System.Drawing.Point(200, 438);
            this.txtCurDiscount.Name = "txtCurDiscount";
            this.txtCurDiscount.Size = new System.Drawing.Size(150, 28);
            this.txtCurDiscount.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtQuantity.Location = new System.Drawing.Point(200, 476);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 28);
            this.txtQuantity.TabIndex = 11;
            // 
            // txtPhoto
            // 
            this.txtPhoto.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtPhoto.Location = new System.Drawing.Point(200, 514);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(300, 28);
            this.txtPhoto.TabIndex = 12;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbCategory.Location = new System.Drawing.Point(200, 172);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 28);
            this.cmbCategory.TabIndex = 3;
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbManufacturer.Location = new System.Drawing.Point(200, 210);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(300, 28);
            this.cmbManufacturer.TabIndex = 4;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbSupplier.Location = new System.Drawing.Point(200, 248);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(300, 28);
            this.cmbSupplier.TabIndex = 5;
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbUnit.Location = new System.Drawing.Point(200, 286);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(300, 28);
            this.cmbUnit.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbStatus.Location = new System.Drawing.Point(200, 324);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 28);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(80, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(300, 570);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProductEditForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(650, 640);
            this.Controls.Add(this.lblArticle);
            this.Controls.Add(this.txtArticle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.lblMaxDiscount);
            this.Controls.Add(this.txtMaxDiscount);
            this.Controls.Add(this.lblCurDiscount);
            this.Controls.Add(this.txtCurDiscount);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}