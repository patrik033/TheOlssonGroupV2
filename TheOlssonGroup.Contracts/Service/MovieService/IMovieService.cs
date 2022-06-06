using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.Paging;

namespace TheOlssonGroup.Contracts.Service.MovieService
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<Movie>>> GetFeaturedMoviesAsync();
        Task<ServiceResponse<List<Movie>>> GetAllMoviesAsync(int? id);
        Task<ServiceResponse<Movie>> GetSingleMovie(int id);
        Task<ServiceResponse<List<Genre>>> GetMovieGenresAsync();
        Task<ServiceResponse<Genre>> GetMovieGenreAsync(int id);
        Task<ServiceResponse<List<Movie>>> GetMoviesByGenre(string genreUrl);
        Task<List<MovieDtoRecord>> GetMoviesAndGenresAsync(string genreUrl);
        Task<PagedList<MovieDtoRecord>> GetMoviesPagedxxxxxx(MovieParameters movieParameters);
        Task<Dictionary<string, int>> GetStatsSales();
    }
}
