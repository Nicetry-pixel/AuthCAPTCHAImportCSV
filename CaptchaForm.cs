using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class CaptchaForm : Form
    {
        private readonly string expectedAnswer;

        public CaptchaForm(Image captchaImage, string answer)
        {
            InitializeComponent();
            this.expectedAnswer = answer;
            this.captchaPictureBox.Image = captchaImage;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (captchaTextBox.Text.Trim().Equals(expectedAnswer, StringComparison.OrdinalIgnoreCase))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
