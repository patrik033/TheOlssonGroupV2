
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheOlssonGroup.Contracts.Service.MovieService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.Paging;
using TheOlssonGroup.Repository.MovieExtensions;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.Service.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly OlssonContext _context;
        private readonly IMapper _mapper;
        public MovieService(OlssonContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Movie>>> GetAllMoviesAsync(int? id = null)
        {
            if (id != null)
            {
                var response = new ServiceResponse<List<Movie>>
                {
                    Data = await _context.Movies
                    .Where(x => x.GenreId == id)
                    .ToListAsync()
                };
                return response;
            }
            else
            {
                var response = new ServiceResponse<List<Movie>>
                {
                    Data = await _context.Movies
                    .ToListAsync()
                };
                return response;
            }
        }


        public async Task<ServiceResponse<List<Movie>>> GetFeaturedMoviesAsync()
        {
            var respone = new ServiceResponse<List<Movie>>
            {
                Data = await _context.Movies
                .Where(m => m.Featured == true)
                .ToListAsync()

            };
            return respone;
        }

        
     
        public async Task<ServiceResponse<List<Genre>>> GetMovieGenresAsync()
        {
            var response = new ServiceResponse<List<Genre>>
            {
                Data = await _context.Genres.ToListAsync()   
            };
            return response;
        }

        public async Task<ServiceResponse<Movie>> GetSingleMovie(int id)
        {
            var response = new ServiceResponse<Movie>();
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                response.Success = false;
                response.Message = "This movie doesn't exist";
            }
            else
            {
                response.Data = movie;
            }
            return response;
        }

        public async Task<ServiceResponse<Genre>> GetMovieGenreAsync(int id)
        {
            var response = new ServiceResponse<Genre>();
            var genre = await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
            if (genre is null)
            {
                response.Success = false;
                response.Message = "This genre dosen't exist";
            }
            else
            {
                response.Data = genre;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Movie>>> GetMoviesByGenre(string genreUrl)
        {
            var response = new ServiceResponse<List<Movie>>
            {
                Data = await _context.Movies
                .Where(m => m.Genre.GenreUrl.ToLower() == genreUrl.ToLower())
                .ToListAsync()
            };
            return response;
        }
        //denna funkar nu
        public async Task<List<MovieDtoRecord>> GetMoviesAndGenresAsync(string genreUrl)
        {
            try
            {
                var moviesNgenres =  await _context.Movies.Include(x => x.Genre).Where(x => x.Genre.GenreName.ToLower() == genreUrl.ToLower()).ToListAsync();
                var movieDtoRecord = _mapper.Map<List<MovieDtoRecord>>(moviesNgenres);
                return movieDtoRecord;
            }
            catch 
            {
                throw;
            }
        }

        
        public async Task<PagedList<MovieDtoRecord>> GetMoviesPagedxxxxxx(/*MetaData metaData, [FromQuery] */MovieParameters movieParameters)
        {
                var moviesWithMetaData = await _context.Movies.Include(x => x.Genre)
                                /*.Where(x => x.GenreId == x.Genre.Id)*/.Search(movieParameters.SearchTerm)
                                    .ToListAsync();
            
                if (moviesWithMetaData.Count() == 0)
                {
                    var response = new ServiceResponse<List<MovieDtoRecord>>
                    {
                        Data = null,
                        Success = false,
                        Message = "No data to show"
                    };
                    var respone = PagedList<MovieDtoRecord>.ToPagedList(response.Data, movieParameters.PageNumber, movieParameters.PageSize);
                return respone;
                }
                else
                {
                //var responseDto = new ServiceResponse<List<MovieDtoRecord>>
                //{
                var responseDto = _mapper.Map<List<MovieDtoRecord>>(moviesWithMetaData);
                        //Success = true,
                        //Message = "Found movies in that genre"
                    //};

                    var pagedList = PagedList<MovieDtoRecord>.ToPagedList(responseDto, movieParameters.PageNumber, movieParameters.PageSize);
                    return (pagedList);
            }



}

        public async Task<Dictionary<string, int>> GetStatsSales()
        {
            var genreNamesForX = await _context.Movies.Include(x => x.Genre).Select(x => new { x.Genre.GenreName, x.Title }).Distinct().ToListAsync();
            var movieStats = await _context.ListOrdersDto.GroupBy(x => x.Title).Select(x => new
            {
                Title = x.Key,
                TotalSales = x.Sum(x => x.Quantity),
            }).Distinct().ToListAsync();
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var genre in genreNamesForX)
            {
                foreach (var movie in movieStats)
                {
                    if (genre.Title == movie.Title)
                    {
                        if (map.ContainsKey(genre.GenreName))
                        {
                            map[genre.GenreName].Add(movie.TotalSales);
                        }
                        else if (!map.ContainsKey(genre.GenreName))
                        {
                            map.Add(genre.GenreName, new List<int>());
                            map[genre.GenreName].Add(movie.TotalSales);
                        }
                    }
                }
            }
            foreach (var movie in map)
            {
                int buffer = 0;
                buffer = movie.Value.Sum();
                result.Add(movie.Key, buffer);
            }
            return result;
        }
    }
}
