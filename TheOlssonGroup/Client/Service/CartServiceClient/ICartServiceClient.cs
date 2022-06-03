using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.CartServiceClient
{
    public interface ICartServiceClient
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<MovieCartDto>> GetCartProducts();
        Task RemoveMovieFromCart(int productId);
        Task UpdateQuantity(MovieCartDto movie);
        Task<string> Checkout();
        Task EmptyCart();
    }
}
