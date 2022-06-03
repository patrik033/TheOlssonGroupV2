using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.Contratct
{
    public interface IGenreServiceClient
    {
        List<Genre> Genres { get; set; }
        Task GetAllGenres();
        Task GetAllGenresAndMoviesAsync();
        Task<ServiceResponse<Genre>> GetOneGenre(string genreUrl);
        Task Save(Genre genre);
        Task Delete (string CategoryUrl);
    }
}
