using TheOlssonGroup.Entities.DTOs;

namespace TheOlssonGroup.Client.Service.EmailServiceClient
{
    public interface IEmailServiceClient
    {
        public Task SendEmail(EmailDto email);
    }
}
