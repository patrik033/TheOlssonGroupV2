using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.GenreService
{
    public interface IGenreService
    {
        Task<ServiceResponse<List<Genre>>> GetAllGenresAsync();
        Task<ServiceResponse<Genre>> SaveGenreAsync(Genre genre);
        Task<List<Movie>> GetGenresAndMoviesAsync(int id);
        Task Delete(string genreUrl);
        Task<ServiceResponse<Genre>> GetOneGenre(string genreUrl);
    }
}
