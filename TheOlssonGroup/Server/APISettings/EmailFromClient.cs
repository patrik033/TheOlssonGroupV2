using Microsoft.AspNetCore.Identity.UI.Services;

namespace TheOlssonGroup.Server.APISettings
{
    public class EmailFromClient : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
