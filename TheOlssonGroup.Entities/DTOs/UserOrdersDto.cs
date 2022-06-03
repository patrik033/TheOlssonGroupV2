using System.ComponentModel.DataAnnotations.Schema;


namespace TheOlssonGroup.Entities.DTOs
{
    public class UserOrdersDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<ListOrdersDto> BoughtProducts { get; set; }
        //public int BoughtProductsId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
