using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheOlssonGroup.Entities.DatabaseModels
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public float Rating { get; set; }
        public DateTime? ProductionYear { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? PosterImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
        public bool Featured { get; set; } = false;
    }
}
