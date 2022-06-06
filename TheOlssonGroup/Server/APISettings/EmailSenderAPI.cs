using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MailKit.Net.Smtp;

namespace BlazorApp1.Server.APIHelper
{
    public class EmailSenderAPI : IEmailSender
    {

        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        public  Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                //configuration
                var emailToSender = new MimeMessage();
                emailToSender.From.Add(MailboxAddress.Parse("theolssongroup@gmail.com"));
                emailToSender.To.Add(MailboxAddress.Parse(email));
                emailToSender.Subject = subject;
                emailToSender.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

                //sending the email
                using (var emailClient = new SmtpClient())
                {
                    //denna gör att du kan skicka mail - ta inte bort
                    emailClient.CheckCertificateRevocation = false;
                    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    emailClient.Authenticate("theolssongroup@gmail.com", "lrkbdxrsqbsrgcaw");
                    emailClient.Send(emailToSender);
                    emailClient.Disconnect(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.CompletedTask;
        }
    }
}
