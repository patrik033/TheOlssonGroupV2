using TheOlssonGroup.Client.Features;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.Paging;

namespace TheOlssonGroup.Client.Service.Contratct
{
    public interface IMovieServiceClient
    {
        event Action MoviesChanged;
        List<Movie> Movies { get; set; }
        string Message { get; set; }
        Task GetAllMovies();
        Task GetFeaturedMovies();
        Task<ServiceResponse<Movie>> GetSingleMovie(int id);
        Task<List<MovieDtoRecord>> GetMoviesAndGenresAsync(string genreUrl);
        Task<PagingResponse<MovieDtoRecord>> GetPagingResponse(MovieParameters movieParameters);
        Task<Dictionary<string, int>> GetSalesStatsByGenre();

    }
}
