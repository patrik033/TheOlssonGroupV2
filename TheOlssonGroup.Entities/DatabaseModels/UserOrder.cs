using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheOlssonGroup.Entities.DTOs;

namespace TheOlssonGroup.Entities.DatabaseModels
{

    public class UserOrder
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<ListOrdersDto>? BoughtProducts { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
