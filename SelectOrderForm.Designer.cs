namespace AuthCAPTCHAImportCSV
{
    partial class SelectOrderForm
    {
        private System.Windows.Forms.CheckBox chkShowPersonalData;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvOrders;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectOrderForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            this.chkShowPersonalData = new System.Windows.Forms.CheckBox();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.lblUser);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 50);
            this.topPanel.TabIndex = 1;
            this.topPanel.Controls.Add(this.chkShowPersonalData);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(604, 14);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(45, 23);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "ФИО";
            //
            // CheckBox
            //
            this.chkShowPersonalData.AutoSize = true;
            this.chkShowPersonalData.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chkShowPersonalData.Location = new System.Drawing.Point(160, 18);
            this.chkShowPersonalData.Name = "chkShowPersonalData";
            this.chkShowPersonalData.Size = new System.Drawing.Size(280, 24);
            this.chkShowPersonalData.Text = "Показать персональные данные";
            this.chkShowPersonalData.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Выход";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 50);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.Size = new System.Drawing.Size(900, 500);
            this.dgvOrders.TabIndex = 0;
            // 
            // SelectOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "SelectOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр заказов";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }
    }
}