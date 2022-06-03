using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheOlssonGroup.Contracts.Service.CartService;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;


namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class MovieCartController : ControllerBase
    {
        private readonly ICartService _service;

        public MovieCartController(ICartService service)
        {
            _service = service;
        }
        [MapToApiVersion("1.0")]
        [HttpPost("movie")]
        public async Task<ActionResult<ServiceResponse<List<MovieCartDto>>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = await _service.GetCartProducts(cartItems);
            return Ok(result);
        }
    }
}
