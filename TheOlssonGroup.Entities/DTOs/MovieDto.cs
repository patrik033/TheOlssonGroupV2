namespace TheOlssonGroup.Entities.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
        public DateTime? ProductionYear { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? PosterImageUrl { get; set; }        
        public decimal Price { get; set; }
        public string GenreName { get; set; }
        public int GenreId { get; set; }
        public bool Featured { get; set; } 
    }
}
