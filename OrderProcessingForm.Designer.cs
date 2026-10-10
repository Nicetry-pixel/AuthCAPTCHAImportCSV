namespace AuthCAPTCHAImportCSV
{
    partial class OrderProcessingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.DataGridView dgvOrders;

        private System.Windows.Forms.Panel pagerPanel;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnNext;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miViewDetails;
        private System.Windows.Forms.ToolStripMenuItem miChangeStatus;
        private System.Windows.Forms.ToolStripMenuItem miChangeDelivery;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.pagerPanel = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pagerPanel.SuspendLayout();
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
            this.headerPanel.Size = new System.Drawing.Size(1100, 70);
            this.headerPanel.TabIndex = 3;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::AuthCAPTCHAImportCSV.Properties.Resources.logo;
            this.logoPictureBox.Location = new System.Drawing.Point(10, 8);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(54, 54);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(75, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(248, 31);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Управление заказами";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(850, 25);
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
            this.btnBack.Location = new System.Drawing.Point(400, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.filterPanel.Controls.Add(this.lblSearch);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.lblStatusFilter);
            this.filterPanel.Controls.Add(this.cmbStatusFilter);
            this.filterPanel.Controls.Add(this.lblFrom);
            this.filterPanel.Controls.Add(this.dtpFrom);
            this.filterPanel.Controls.Add(this.lblTo);
            this.filterPanel.Controls.Add(this.dtpTo);
            this.filterPanel.Controls.Add(this.lblSort);
            this.filterPanel.Controls.Add(this.cmbSort);
            this.filterPanel.Controls.Add(this.lblCount);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 70);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1100, 90);
            this.filterPanel.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblSearch.Location = new System.Drawing.Point(10, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(160, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск (ФИО клиента):";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtSearch.Location = new System.Drawing.Point(10, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblStatusFilter.Location = new System.Drawing.Point(310, 8);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(56, 19);
            this.lblStatusFilter.TabIndex = 1;
            this.lblStatusFilter.Text = "Статус:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbStatusFilter.Location = new System.Drawing.Point(310, 32);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(180, 26);
            this.cmbStatusFilter.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblFrom.Location = new System.Drawing.Point(510, 8);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(56, 19);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "Дата с:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(510, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 26);
            this.dtpFrom.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblTo.Location = new System.Drawing.Point(650, 8);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(66, 19);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "Дата по:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(650, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 26);
            this.dtpTo.TabIndex = 5;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblSort.Location = new System.Drawing.Point(790, 8);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(88, 19);
            this.lblSort.TabIndex = 6;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbSort.Location = new System.Drawing.Point(790, 32);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(180, 26);
            this.cmbSort.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(990, 35);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(54, 19);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "0 из 0";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 160);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1100, 440);
            this.dgvOrders.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewDetails,
            this.miChangeStatus,
            this.miChangeDelivery});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(207, 70);
            // 
            // miViewDetails
            // 
            this.miViewDetails.Name = "miViewDetails";
            this.miViewDetails.Size = new System.Drawing.Size(206, 22);
            this.miViewDetails.Text = "Просмотр заказа";
            // 
            // miChangeStatus
            // 
            this.miChangeStatus.Name = "miChangeStatus";
            this.miChangeStatus.Size = new System.Drawing.Size(206, 22);
            this.miChangeStatus.Text = "Изменить статус";
            // 
            // miChangeDelivery
            // 
            this.miChangeDelivery.Name = "miChangeDelivery";
            this.miChangeDelivery.Size = new System.Drawing.Size(206, 22);
            this.miChangeDelivery.Text = "Изменить дату доставки";
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.Color.White;
            this.pagerPanel.Controls.Add(this.btnPrev);
            this.pagerPanel.Controls.Add(this.lblPage);
            this.pagerPanel.Controls.Add(this.btnNext);
            this.pagerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerPanel.Location = new System.Drawing.Point(0, 600);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(1100, 50);
            this.pagerPanel.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnPrev.Location = new System.Drawing.Point(400, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(120, 32);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "← Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblPage.Location = new System.Drawing.Point(530, 15);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(119, 20);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnNext.Location = new System.Drawing.Point(660, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 32);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Вперёд →";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // OrderProcessingForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pagerPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "OrderProcessingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление заказами";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pagerPanel.ResumeLayout(false);
            this.pagerPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}