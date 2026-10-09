namespace AuthCAPTCHAImportCSV
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPickupAddress;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPickupAddress = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();

            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 170);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Text = "Просмотр заказа";

            // lblOrderId
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblOrderId.Location = new System.Drawing.Point(15, 45);
            this.lblOrderId.Text = "№ заказа:";

            // lblOrderCode
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblOrderCode.Location = new System.Drawing.Point(15, 70);
            this.lblOrderCode.Text = "Код:";

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblClient.Location = new System.Drawing.Point(15, 95);
            this.lblClient.Text = "ФИО клиента:";

            // lblOrderDate
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblOrderDate.Location = new System.Drawing.Point(400, 45);
            this.lblOrderDate.Text = "Дата заказа:";

            // lblDeliveryDate
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblDeliveryDate.Location = new System.Drawing.Point(400, 70);
            this.lblDeliveryDate.Text = "Дата доставки:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblStatus.Location = new System.Drawing.Point(400, 95);
            this.lblStatus.Text = "Статус:";

            // lblPickupAddress
            this.lblPickupAddress.AutoSize = true;
            this.lblPickupAddress.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblPickupAddress.Location = new System.Drawing.Point(15, 125);
            this.lblPickupAddress.Text = "Пункт выдачи:";

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 170);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(800, 330);
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Height = 45;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;

            // OrderDetailsForm
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.topPanel);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.lblOrderId);
            this.topPanel.Controls.Add(this.lblOrderCode);
            this.topPanel.Controls.Add(this.lblClient);
            this.topPanel.Controls.Add(this.lblOrderDate);
            this.topPanel.Controls.Add(this.lblDeliveryDate);
            this.topPanel.Controls.Add(this.lblStatus);
            this.topPanel.Controls.Add(this.lblPickupAddress);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр заказа";
            this.BackColor = System.Drawing.Color.White;

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}