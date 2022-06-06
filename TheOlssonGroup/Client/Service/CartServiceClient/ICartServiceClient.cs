using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.CartServiceClient
{
    public interface ICartServiceClient
    {
        event Action OnChange;
        Task<List<CartItem>> GetCartItems();
        Task<List<MovieCartDto>> GetCartProducts();
        Task RemoveMovieFromCart(int productId);
        Task<string> Checkout();
        Task EmptyCart();
        public Task Add(CartItem cartItem);
        public Task Decrease(CartItem cartItem);
    }
}
