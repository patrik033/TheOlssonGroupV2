using System.Net.Http.Json;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.UserServiceClient
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _http;

        public UserServiceClient(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<string>> GetUserId(string userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<string>>($"api/v1/user/{userId}");
            return result;
        }

        public async Task SaveUser(UserOrdersDto userOrdersDto)
        {
            var result = await _http.PostAsJsonAsync("api/v1/user", userOrdersDto);
        }
    }
}
