using Microsoft.EntityFrameworkCore;
using TheOlssonGroup.Contracts.Service.CartService;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Repository.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly OlssonContext _context;

        public CartService(OlssonContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MovieCartDto>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<MovieCartDto>>
            {
                Data = new List<MovieCartDto>()
            };

            foreach (var item in cartItems)
            {
                var product = await _context.Movies
                    .Where(p => p.Id == item.MovieId)
                    .FirstOrDefaultAsync();
                if (product == null)
                {
                    continue;
                }
                var cartProduct = new MovieCartDto
                {
                    MovieId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.PosterImageUrl,
                    Price = product.Price,
                    Quantity = item.Quantity,
                };
                result.Data.Add(cartProduct);
            }
            return result;
        }
    }
}
