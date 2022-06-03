using Stripe.Checkout;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Contracts.Service.StripeService
{
    public interface IStripeService
    {
        Session CreateCheckoutSession(List<CartItem> items);
    }
}
