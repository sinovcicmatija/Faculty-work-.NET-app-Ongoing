using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for TOTPWindow.xaml
    /// </summary>
    public partial class TOTPWindow : Window
    {
        private readonly byte[] _totpKey;
        public TOTPWindow(byte[] totpKey)
        {
            InitializeComponent();
            _totpKey = totpKey;
        }

        private void txtTOTP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            var totp = new Totp(_totpKey);
            bool isValid = totp.VerifyTotp(txtTOTP.Text, out long timeStepMatched, new VerificationWindow(2, 2));

            if (isValid)
            {
                
                AppWindow appWindow = new AppWindow();
                this.Hide();
                appWindow.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Krivo unešeni kod!");
            }
        }
    }
}
