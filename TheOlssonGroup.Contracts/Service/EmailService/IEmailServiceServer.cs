using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.EmailService
{
    public interface IEmailServiceServer
    {
        Task<ServiceResponse<EmailDto>> SendEmail(EmailDto emailSent);
    }
}
