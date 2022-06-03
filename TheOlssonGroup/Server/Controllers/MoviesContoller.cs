using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TheOlssonGroup.Contracts.Service.MovieService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Entities.Paging;



namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/movie")]
    //[Route("api/movie")]
    public class MoviesContoller : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMoviePostService _moviePostService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoviesContoller(IMovieService movieService, IMoviePostService moviePostService,IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _moviePostService = moviePostService;
            _webHostEnvironment = webHostEnvironment;
        }
        #region GetMethods
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAllMovies(int? id)
        {
            var movies = await _movieService.GetAllMoviesAsync(id);
            return Ok(movies);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetFeaturedMoviesAsync()
        {
            var featuredMovies = await _movieService.GetFeaturedMoviesAsync();
            return Ok(featuredMovies);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("GetMovieStatsYes")]
        public async Task<ActionResult<Dictionary<string, int>>> GetSalesStats()
        {
            var result = await _movieService.GetStatsSales();
            return Ok(result);
        }


        [MapToApiVersion("1.0")]
        [HttpGet("{id}",Name = "GetSingleMovie")]
        public async Task<ActionResult<ServiceResponse<Movie>>> GetSingleMovie(int id)
        {
            var movie = await _movieService.GetSingleMovie(id);
            return Ok(movie);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("genre/{genreUrl}")]
        public async Task<ActionResult<List<MovieDtoRecord>>> GetAllMoviesByGenre(string genreUrl)
        {
            var result = await _movieService.GetMoviesAndGenresAsync(genreUrl);
            return Ok(result);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("GetMoviesPaged/hejpa")]//ändara från post till get
         public async Task<ActionResult<PagedList<MovieDtoRecord>>> GetMoviesPagedxxxxxx(/*MetaData metaData,*/ [FromQuery] MovieParameters movieParameters)
        {
            var buff = movieParameters.PageNumber.ToString();
           
            var movies = await _movieService.GetMoviesPagedxxxxxx(/*metaData,*/movieParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(movies.MetaData));
            return Ok(movies);
        }
        #endregion
        [MapToApiVersion("1.0")]
        [HttpPost]
        //TODO: fixa created at route
        public async Task<ActionResult<ServiceResponse<Movie>>> CreateMovie(Movie movie)
        {
            if (movie == null)
            {
                return Problem("Entity set 'OlssonContext.Movies'  is null.");
            }
            var result = await _moviePostService.Save(movie);
            return CreatedAtRoute("GetSingleMovie",new { id = movie.Id }, movie);
        }



       

        [MapToApiVersion("1.0")]
        [HttpPut("edit")]
        public async Task<ActionResult<ServiceResponse<Movie>>> EditMovie(Movie movie)
        {
            if (movie == null)
            {
                return NotFound();
            }
            var result = await _moviePostService.Edit(movie);
            return Ok(movie);
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<Movie>>> DeleteMovie(int id)
        {
            if (id < 1)
                return NotFound();
            else
            {
                var result = await _moviePostService.Delete(id);
                return NoContent();
            }
        }


    }
}
