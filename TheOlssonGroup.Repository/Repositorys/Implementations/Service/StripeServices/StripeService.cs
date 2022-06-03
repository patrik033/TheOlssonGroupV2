using Stripe;
using Stripe.Checkout;
using TheOlssonGroup.Contracts.Service.StripeService;
using TheOlssonGroup.Entities.Models;

namespace TheOlssonGroup.Repository.Repositorys.Service.StripeServices
{
    public class StripeService : IStripeService
    {
        public StripeService()
        {
            StripeConfiguration.ApiKey = "sk_test_51L17hRG6o6awavjHPuNN2ePMDQHvWCBDr1Gg8OyAiTQSJpB3MttjdANU9nW1G1PzokDPkmDKbZ7EEAPYgIJA49LB00Sdd6uEVT";
        }
        public Session CreateCheckoutSession(List<CartItem> items)
        {
            var lineItems = new List<SessionLineItemOptions>();
            items.ForEach(x => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = x.Price * 100,
                    Currency = "sek",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = x.Title,
                        //Images = new List<string> { x.Image }
                    }
                },
                Quantity = x.Quantity
            }));
            //options - for the session
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                //List of what is beeing purchased
                LineItems = lineItems,
                Mode = "payment",



                SuccessUrl = "https://localhost:7284/success",
                CancelUrl = "https://localhost:7284/failed",
                //SuccessUrl = "https://theolssongroup.azurewebsites.net/success",
                //CancelUrl = "https://theolssongroup.azurewebsites.net/failed",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
