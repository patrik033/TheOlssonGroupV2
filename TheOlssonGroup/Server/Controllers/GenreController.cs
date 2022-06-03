using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheOlssonGroup.Contracts.Service.GenreService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Models;



namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetAllGenresAsync()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("{genreUrl}")]
        public async Task<ActionResult<ServiceResponse<Genre>>> GetOneGenreAsync(string genreUrl)
        {
            var genres = await _genreService.GetOneGenre(genreUrl);
            return Ok(genres);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetGenresAndMovies(int id)
        {
            var genresAndMovies = await _genreService.GetGenresAndMoviesAsync(id);
            return Ok(genresAndMovies);
        }
        [MapToApiVersion("1.0")]
        [HttpPost("create")]
        public async Task<ActionResult<Genre>> CreateGenre(Genre genre)
        {
            var result = await _genreService.SaveGenreAsync(genre);
            return Ok(result);
        }
        [MapToApiVersion("1.0")]
        [HttpDelete("{genreUrl}")]
        public async Task<ActionResult> DeleteGenreAndMovies(string genreUrl)
        {
            await _genreService.Delete(genreUrl);
            return NoContent();
        }
    }
}
