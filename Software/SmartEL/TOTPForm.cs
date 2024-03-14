using OtpNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEL
{
    public partial class TOTPForm : Form
    {
        private readonly byte[] _totpKey;
        public TOTPForm(byte[] totpKey)
        {
            InitializeComponent();
            _totpKey = totpKey;
        }

        private void TOTPForm_Load(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            var totp = new Totp(_totpKey);
            bool isValid = totp.VerifyTotp(txtTOTP.Text, out long timeStepMatched, new VerificationWindow(2, 2)); 
          
            if (isValid)
            {
                MainForm mainForm = new MainForm();
                this.Hide(); 
                mainForm.ShowDialog();

                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Krivo unešeni kod!");
            }
        }
    }
}
