using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheOlssonGroup.Contracts.Service.EmailService;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;


namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServiceServer _emailService;

        public EmailController(IEmailServiceServer emailService)
        {
            _emailService = emailService;
        }
        [MapToApiVersion("1.0")]
        [HttpPost] 
        public async Task<ActionResult<ServiceResponse<EmailDto>>> SendEmail(EmailDto emailSent)
        {
            var email = await _emailService.SendEmail(emailSent);
            return Ok(email);
        }
    }
}
