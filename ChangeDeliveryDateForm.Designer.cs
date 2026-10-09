namespace AuthCAPTCHAImportCSV
{
    partial class ChangeDeliveryDateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.DateTimePicker dtpDelivery;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDelivery = new System.Windows.Forms.Label();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblDelivery.Location = new System.Drawing.Point(20, 25);
            this.lblDelivery.Text = "Новая дата доставки:";

            this.dtpDelivery.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.dtpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelivery.Location = new System.Drawing.Point(220, 22);
            this.dtpDelivery.Name = "dtpDelivery";
            this.dtpDelivery.Size = new System.Drawing.Size(200, 28);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(40, 80);
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;

            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(240, 80);
            this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;

            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.dtpDelivery);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeDeliveryDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменение даты доставки";
            this.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.ResumeLayout(false);
        }
    }
}