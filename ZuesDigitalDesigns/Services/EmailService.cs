using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using MailKit;
using Microsoft.Extensions.Configuration;

namespace ZuesDigitalDesigns.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task SendEmailAsync(
            string name, 
            string emailAddress, 
            string messageBody)
        {
            MimeMessage email = new MimeMessage();
            
            // Sender (Your authenticated app email)
            email.From.Add(new MailboxAddress(
                "Zues Digital Web", 
                _config["Email:Address"]));
                
            // Receiver (You, getting the notification)
            email.To.Add(new MailboxAddress(
                "Zac Kimball", 
                _config["Email:Address"]));
                
            email.Subject = $"New Quote Request from {name}";

            BodyBuilder builder = new BodyBuilder();
            builder.TextBody = $"Name: {name}\n" +
                               $"Email: {emailAddress}\n\n" +
                               $"Message:\n{messageBody}";
                               
            email.Body = builder.ToMessageBody();

            // Sets Reply-To so you can easily hit reply in your inbox
            email.ReplyTo.Add(new MailboxAddress(name, emailAddress));

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.CheckCertificateRevocation = false;
                
                await smtp.ConnectAsync(
                    _config["Email:Host"], 
                    int.Parse(_config["Email:Port"]), 
                    SecureSocketOptions.StartTls);
                    
                await smtp.AuthenticateAsync(
                    _config["Email:Address"], 
                    _config["Email:Password"]);
                    
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}