using AutoMapper;
using TheOlssonGroup.Contracts.Service.MovieService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.Service.MovieService
{
    public class MoviePostService : IMoviePostService
    {

        private readonly OlssonContext _context;
        private readonly IMapper _mapper;
        public MoviePostService(OlssonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Movie>> Delete(int id)
        {
            var result = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Movies.Remove(result);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Movie>
                {
                    Data = result
                };
            }
            return new ServiceResponse<Movie>
            {
                Data = null
                ,
                Message = "Error"
            };
        }

        public async Task<ServiceResponse<Movie>> Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Movie>
            {
                Data = movie
            };
        }

        public async Task<ServiceResponse<Movie>> Save(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Movie>
            {
                Data = movie
            };

        }
    }
}
