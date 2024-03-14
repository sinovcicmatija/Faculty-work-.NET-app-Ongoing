using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class EmailService
    {
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("smartelhotel@gmail.com", "lxnv rblp yoqh giqv"),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("smartelhotel@gmail.com"),
                Subject = subject,
                Body = body
            };
            mailMessage.To.Add(recipientEmail);

            client.Send(mailMessage);
        }
    }
}
