using System.Net.Http.Json;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service
{
    public class GenreServiceClient : IGenreServiceClient
    {
        private readonly HttpClient _http;

        public GenreServiceClient(HttpClient http)
        {
            _http = http;
        }

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public Genre OneGenre { get; set; } = new Genre();
        public async Task GetAllGenres()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Genre>>>("api/v1/genre");
            if(response != null && response.Data != null)
            {
                Genres = response.Data;
            }
        }

        public async Task<ServiceResponse<Genre>> GetOneGenre(string genreUrl)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Genre>>($"api/v1/genre/{genreUrl}");
            return response;
        }

        
        public async Task GetAllGenresAndMoviesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Genre>>>("api/v1/genre/all");
            if(response != null && response.Data != null)
            {
                Genres = response.Data;
            } 
        }

        public async Task Save(Genre genre)
        {
            await _http.PostAsJsonAsync($"api/v1/Genre/create", genre);
        }

        public async Task Delete(string CategoryUrl)
        {
            await _http.DeleteAsync($"api/v1/Genre/{CategoryUrl}");

        }
    }
}
