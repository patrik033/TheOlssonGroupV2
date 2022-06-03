using System.ComponentModel.DataAnnotations.Schema;
using TheOlssonGroup.Entities.DatabaseModels;

namespace TheOlssonGroup.Entities.DTOs
{
    public class ListOrdersDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public UserOrder? UserOrder { get; set; }
    }
}
