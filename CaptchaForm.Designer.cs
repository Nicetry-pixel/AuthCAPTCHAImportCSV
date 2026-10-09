namespace AuthCAPTCHAImportCSV
{
    partial class CaptchaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox captchaPictureBox;
        private System.Windows.Forms.TextBox captchaTextBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label instructionLabel;

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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptchaForm));
            this.captchaTextBox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.captchaPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captchaTextBox
            // 
            this.captchaTextBox.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.captchaTextBox.Location = new System.Drawing.Point(25, 480);
            this.captchaTextBox.Name = "captchaTextBox";
            this.captchaTextBox.Size = new System.Drawing.Size(260, 34);
            this.captchaTextBox.TabIndex = 2;
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.checkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.checkButton.Location = new System.Drawing.Point(300, 480);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(125, 33);
            this.checkButton.TabIndex = 3;
            this.checkButton.Text = "Проверить";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.instructionLabel.Location = new System.Drawing.Point(110, 20);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(195, 23);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.Text = "Введите код с картинки:";
            // 
            // captchaPictureBox
            // 
            this.captchaPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.captchaPictureBox.Image = global::AuthCAPTCHAImportCSV.Properties.Resources.Captcha2;
            this.captchaPictureBox.Location = new System.Drawing.Point(25, 60);
            this.captchaPictureBox.Name = "captchaPictureBox";
            this.captchaPictureBox.Size = new System.Drawing.Size(400, 400);
            this.captchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.captchaPictureBox.TabIndex = 1;
            this.captchaPictureBox.TabStop = false;
            // 
            // CaptchaForm
            // 
            this.AcceptButton = this.checkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(450, 540);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.captchaTextBox);
            this.Controls.Add(this.captchaPictureBox);
            this.Controls.Add(this.instructionLabel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptchaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CAPTCHA";
            ((System.ComponentModel.ISupportInitialize)(this.captchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}