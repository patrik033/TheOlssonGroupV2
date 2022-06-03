using System.Net.Http.Json;
using TheOlssonGroup.Entities.DTOs;

namespace TheOlssonGroup.Client.Service.EmailServiceClient
{
    public class EmailServiceClient : IEmailServiceClient
    {
        private readonly HttpClient _http;

        public EmailServiceClient(HttpClient http)
        {
            _http = http;
        }
        public async Task SendEmail(EmailDto email)
        {
              await _http.PostAsJsonAsync($"api/v1/email", email);
        }
    }
}
