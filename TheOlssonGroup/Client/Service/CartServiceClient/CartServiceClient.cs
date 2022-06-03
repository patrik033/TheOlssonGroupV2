using System.Net.Http.Json;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Client.Service.CartServiceClient
{
    public class CartServiceClient : ICartServiceClient
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;

        public CartServiceClient(ILocalStorageService localStorageService, HttpClient http)
        {
            _localStorageService = localStorageService;
            _http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart is null)
            {
                cart = new List<CartItem>();
            }
            var doubleItems = cart.Find(x => x.MovieId == cartItem.MovieId);
            if (doubleItems is null)
            {
                cart.Add(cartItem);
            }
            else
            {
                doubleItems.Quantity += cartItem.Quantity;
            }

            await _localStorageService.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }


        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }

        public async Task<List<MovieCartDto>> GetCartProducts()
        {
            var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/v1/MovieCart/movie", cartItems);
            var movieProducts =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<MovieCartDto>>>();
            return movieProducts.Data;
        }

        public async Task RemoveMovieFromCart(int movieId)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var movieVartItem = cart.Find(x => x.MovieId == movieId);
            if (movieVartItem != null)
            {
                cart.Remove(movieVartItem);
                await _localStorageService.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        public async Task<string> Checkout()
        {
            var result = await _http.PostAsJsonAsync("api/v1/stripe/checkout", await GetCartItems());
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }

        public async Task EmptyCart()
        {
            await _localStorageService.RemoveItemAsync("cart");
            OnChange.Invoke();
        }

        public async Task UpdateQuantity(MovieCartDto movie)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var movieItem = cart.Find(x => x.MovieId == movie.MovieId);
            if (movieItem != null)
            {
                movieItem.Quantity = movie.Quantity;
                await _localStorageService.SetItemAsync("cart", cart);
            }
        }
    }
}
