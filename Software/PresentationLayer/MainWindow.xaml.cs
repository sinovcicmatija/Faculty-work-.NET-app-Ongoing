using DataAccessLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OtpNet;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserRolesRepository _rolesRepository;
        public MainWindow()
        {
            InitializeComponent();
            _rolesRepository = new UserRolesRepository(new DatabaseRPP());
            LoadUserRoles();
        }
        private void LoadUserRoles()
        {
            var roles = _rolesRepository.GetAllRoles();
            cmbRole.ItemsSource = roles;

        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository(new DatabaseRPP());
            var authService = new AuthenticationService(userRepository);

            string email = txtEmail.Text; 
            string password = txtPass.Password;
            int selectedRoleId = (int)cmbRole.SelectedValue; 

            if (authService.AuthenticateUser(email, password, selectedRoleId))
            {
                byte[] totpKey = KeyGeneration.GenerateRandomKey(20);
                string totpCode = authService.GenerateTOTPCode(totpKey);

                EmailService emailService = new EmailService();
                emailService.SendEmail(email, "Vaš kod je", $"Vaš kod je: {totpCode}");

                
                TOTPWindow totpWindow = new TOTPWindow(totpKey);
                bool? result = totpWindow.ShowDialog(); 

                if (result == true)
                {
                    MessageBox.Show("Verifikacija uspješna!");
                }
                else
                {
                    MessageBox.Show("Verifikacija neuspješna.");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Nevažeća uloga i/ili email i/ili lozinka");
            }
        }

    }
}
