using Microsoft.AspNetCore.Mvc;
using TheOlssonGroup.Contracts.Service.StripeService;
using TheOlssonGroup.Entities.Models;



namespace TheOlssonGroup.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }
        [MapToApiVersion("1.0")]
        [HttpPost("checkout")]
        public ActionResult Checkout(List<CartItem> item)
        {
            var session = _stripeService.CreateCheckoutSession(item);
            return Ok(session.Url);
        }
    }
}
