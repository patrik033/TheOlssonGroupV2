using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.MovieService
{
    public interface IMoviePostService
    {
        Task<ServiceResponse<Movie>> Save(Movie movie);
        Task<ServiceResponse<Movie>> Edit(Movie movie);
        Task<ServiceResponse<Movie>> Delete(int id);
    }
}
