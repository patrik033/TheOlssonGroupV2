using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<MovieCartDto>>> GetCartProducts(List<CartItem> cartItems);

    }
}
