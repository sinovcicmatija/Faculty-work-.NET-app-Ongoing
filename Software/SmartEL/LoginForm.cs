using BusinessLayer;
using DataAccessLayer;
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
    public partial class LoginForm : Form
    {
        private UserRolesRepository _rolesRepository;
        public LoginForm()
        {
            InitializeComponent();
            _rolesRepository = new UserRolesRepository(new DatabaseRPP());
            LoadUserRoles();
        }
        private void LoadUserRoles()
        {
            var roles = _rolesRepository.GetAllRoles();
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "RoleName"; 
            cmbRole.ValueMember = "idRole"; 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userRepository = new UserRepository(new DatabaseRPP());
            var authService = new AuthenticationService(userRepository);

            string email = txtEmail.Text;
            string password = txtPass.Text;
            int selectedRoleId = (int)cmbRole.SelectedValue;

            if (authService.AuthenticateUser(email, password, selectedRoleId))
            {
                //  EmailService emailService = new EmailService();
                // emailService.SendEmail("markopesa99@gmail.com", "test", "test.");
                byte[] totpKey = KeyGeneration.GenerateRandomKey(20);
                string totpCode = authService.GenerateTOTPCode(totpKey);

                EmailService emailService = new EmailService();
                emailService.SendEmail(email, "Vaš kod je", $"Vaš kod je: {totpCode}");

                TOTPForm totpForm = new TOTPForm(totpKey);
                DialogResult result = totpForm.ShowDialog();

                if (result == DialogResult.OK)
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
                MessageBox.Show("Nevažeći kredencijali.");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
