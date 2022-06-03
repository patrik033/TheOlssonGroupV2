using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MailKit.Net.Smtp;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Contracts.Service.EmailService;

namespace TheOlssonGroup.Server.Service.EmailService
{
    public class EmailServiceServer : IEmailServiceServer, IEmailSender
    {

        public async Task<ServiceResponse<EmailDto>> SendEmail(EmailDto emailSent)
        {
            var emailReceipant = "";
            var subjectMessage = "";
            var htmlMessage = "";

            if (emailSent == null)
            {
                var result = new ServiceResponse<EmailDto>()
                {
                    Data = null,
                    Message = "Nothing was passed on",
                    Success = false,
                };
                return result;
            }
            else
            {
                htmlMessage = ParseMessage(emailSent, out emailReceipant, out subjectMessage, htmlMessage);
                var builder = new BodyBuilder();
                var finalMessage = builder.HtmlBody = String.Format(htmlMessage);
                await SendEmailAsync(emailReceipant, subjectMessage, finalMessage);
                var result = new ServiceResponse<EmailDto>()
                {
                    Data = emailSent,
                    Message = "Success",
                    Success = true
                };
                return result;
            }
        }

        private static string ParseMessage(EmailDto emailSent, out string emailReceipant, out string subjectMessage, string htmlMessage)
        {
            emailReceipant = emailSent.EmailAddress;
            subjectMessage = "Confirmation for your order:";
            htmlMessage += "<p>";
            foreach (var email in emailSent.EmailList)
            {
                htmlMessage += "Title: ";
                htmlMessage += email.Title += "<br>";
                htmlMessage += "Number of items: ";
                htmlMessage += email.Quantity.ToString();
                htmlMessage += "<br>";
                htmlMessage += "Price: ";
                htmlMessage += (email.Price * email.Quantity).ToString();
                htmlMessage += "<br>";
            }
            htmlMessage += "Quantity: ";
            htmlMessage += emailSent.EmailList.Sum(email => email.Quantity).ToString();
            htmlMessage += "<br>";
            htmlMessage += "Price: ";
            htmlMessage += emailSent.EmailList.Sum(email => email.Price).ToString();
            htmlMessage += "<br>";
            htmlMessage += "</p>";
            return htmlMessage;
        }

        public  Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                //configuration
                var emailToSender = new MimeMessage();
                emailToSender.From.Add(MailboxAddress.Parse("hello@bangansbio.com"));
                emailToSender.To.Add(MailboxAddress.Parse(email));
                emailToSender.Subject = subject;
                emailToSender.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

                //sending the email
                using (var emailClient = new SmtpClient())
                {
                    //denna gör att du kan skicka mail - ta inte bort
                    emailClient.CheckCertificateRevocation = false;
                    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    emailClient.Authenticate("bangans.bio@gmail.com", "yxetizawatohpsxh");
                    emailClient.Send(emailToSender);
                    emailClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return Task.CompletedTask;
            
        }
    }
}
