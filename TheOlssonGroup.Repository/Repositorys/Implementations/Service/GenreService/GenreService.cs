using Microsoft.EntityFrameworkCore;
using TheOlssonGroup.Contracts.Service.GenreService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.Service.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly OlssonContext _context;
        public GenreService(OlssonContext context)
        {
            _context = context;
        }

        public async Task Delete(string genreUrl)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.GenreUrl == genreUrl);
            if (genre != null)
            {
                var movies = await _context.Movies.Where(x => x.GenreId == genre.Id).ToListAsync();
                foreach (var movie in movies)
                {
                    if (movies != null)
                    {
                        _context.Entry(movie).State = EntityState.Deleted;
                    }
                }
                _context.Remove(genre);
                _context.SaveChanges();
            }
        }

        public async Task<ServiceResponse<List<Genre>>> GetAllGenresAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            var response = new ServiceResponse<List<Genre>>
            {
                Data = genres
            };
            return response;
        }

        public async Task<List<Movie>> GetGenresAndMoviesAsync(int id)
        {
            try
            {
                var genresAnd = await _context.Movies.Include(x => x.Genre).Where(x => x.GenreId == id).ToListAsync();
                return genresAnd;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ServiceResponse<Genre>> GetOneGenre(string genreUrl)
        {
            var result = new ServiceResponse<Genre>();
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.GenreUrl.ToLower() == genreUrl.ToLower());
            result.Data = genre;
            return result;
        }

        public async Task<ServiceResponse<Genre>> SaveGenreAsync(Genre genre)
        {
            var result = new ServiceResponse<Genre>();
            if (genre != null)
            {
                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
                result.Data = genre;
                result.Success = true;
                result.Message = "Success";
                return result;
            }
            else
            {
                result = new ServiceResponse<Genre>
                {
                    Success = false,
                    Message = "failed to add",
                };
                return result;
            }
        }
    }
}
