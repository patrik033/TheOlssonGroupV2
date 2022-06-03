namespace TheOlssonGroup.Entities.Models
{
    public class CartItem
    {
        public int MovieId { get; set; }
        public int Quantity { get; set; } = 1;
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
