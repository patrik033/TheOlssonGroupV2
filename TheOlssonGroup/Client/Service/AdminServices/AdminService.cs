using System.Net.Http.Json;
using TheOlssonGroup.Entities.DatabaseModels;

namespace TheOlssonGroup.Client.Service.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient _http;

        public AdminService(HttpClient http)
        {
            _http = http;
        }


        public async Task Save(Movie movie)
        {
            await _http.PostAsJsonAsync($"api/v1/movie", movie);
        }

        public async Task Edit(Movie movie)
        {
            await _http.PutAsJsonAsync($"api/v1/movie/edit", movie);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"api/v1/movie/delete/{id}");
        }
    }
}
