using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;
using TheOlssonGroup.Client.Features;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.Paging;

namespace TheOlssonGroup.Client.Service
{
    public class MovieServiceClient : IMovieServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public MovieServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public string Message { get; set; } = "Loading products...";

        public event Action MoviesChanged;

        public async Task GetAllMovies()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Movie>>>("api/v1/movie");
            if (result != null && result.Data != null)
                Movies = result.Data;
        }

        public async Task GetFeaturedMovies()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Movie>>>("api/v1/movie/featured");
            if (response != null && response.Data != null)
            {
                Movies = response.Data.OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            }
        }

        public async Task<ServiceResponse<Movie>> GetSingleMovie(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Movie>>($"api/v1/movie/{id}");
            return result;
        }

        public async Task<List<MovieDtoRecord>> GetMoviesAndGenresAsync(string genreUrl)
        {
            var result = await _httpClient.GetFromJsonAsync<List<MovieDtoRecord>>($"api/v1/movie/genre/{genreUrl}");
            return result;
        }

        public async Task<PagingResponse<MovieDtoRecord>> GetPagingResponse(MovieParameters movieParameters)
        {
            var queryString = new Dictionary<string, string>
            {
                ["pageNumber"] = movieParameters.PageNumber.ToString(),
                ["searchTerm"] = movieParameters.SearchTerm == null ? "" : movieParameters.SearchTerm

            };
            string searchString = "/api/movie/GetMoviesPaged/hejpa?" + queryString.ToString();
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString($"/api/v1/movie/GetMoviesPaged/hejpa?" ,queryString ));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<MovieDtoRecord>
            {
                Items = JsonSerializer.Deserialize<List<MovieDtoRecord>>(content,_options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(),_options)
            };
            return pagingResponse;
        }

        public async Task<Dictionary<string, int>> GetSalesStatsByGenre()
        {
            var result = await _httpClient.GetFromJsonAsync<Dictionary<string, int>>($"api/v1/movie/GetMovieStatsYes");
            return result;
        }
    }
}
