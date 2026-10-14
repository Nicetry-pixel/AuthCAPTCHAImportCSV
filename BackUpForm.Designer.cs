
namespace AuthCAPTCHAImportCSV
{
    partial class BackUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpForm));
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTable = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkHasHeader = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(12, 158);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(170, 40);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(228, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblTable.Location = new System.Drawing.Point(21, 23);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(76, 20);
            this.lblTable.TabIndex = 9;
            this.lblTable.Text = "Таблица:";
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.cmbTable.Location = new System.Drawing.Point(131, 20);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(240, 28);
            this.cmbTable.TabIndex = 10;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblFile.Location = new System.Drawing.Point(21, 68);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(51, 20);
            this.lblFile.TabIndex = 11;
            this.lblFile.Text = "Файл:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtFilePath.Location = new System.Drawing.Point(131, 65);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(180, 28);
            this.txtFilePath.TabIndex = 12;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.btnBrowse.Location = new System.Drawing.Point(321, 65);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 28);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkHasHeader
            // 
            this.chkHasHeader.AutoSize = true;
            this.chkHasHeader.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.chkHasHeader.Location = new System.Drawing.Point(131, 108);
            this.chkHasHeader.Name = "chkHasHeader";
            this.chkHasHeader.Size = new System.Drawing.Size(229, 24);
            this.chkHasHeader.TabIndex = 14;
            this.chkHasHeader.Text = "Первая строка — заголовки";
            // 
            // BackUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(400, 210);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.chkHasHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BackUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Резервное копирование данных";
            this.Load += new System.EventHandler(this.BackUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkHasHeader;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}