using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using BookStore.BusinessLogicLayer.Services.Interfaces;

namespace BookStore.BusinessLogicLayer.Services
{
    public class EmailService: IEmailServices
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", "email"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smpt.gmail.com", 25, false);
                await client.AuthenticateAsync("login@gmail.com", "password");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
