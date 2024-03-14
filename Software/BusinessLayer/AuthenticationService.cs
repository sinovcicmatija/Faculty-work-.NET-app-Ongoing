using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OtpNet;

namespace BusinessLayer
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool AuthenticateUser(string email, string password, int selectedRoleId)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || user.idRole != selectedRoleId) return false;
            return VerifyPasswordHash(password, user.Password);
        }
        private bool VerifyPasswordHash(string password, string storedHash)
        {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString() == storedHash;
                }
        }
        public string GenerateTOTPCode(byte[] secretKey)
        {
            var totp = new Totp(secretKey);
            return totp.ComputeTotp(); 
        }
    }
}
