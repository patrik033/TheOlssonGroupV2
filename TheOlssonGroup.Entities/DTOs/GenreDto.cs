using TheOlssonGroup.Entities.DatabaseModels;


namespace TheOlssonGroup.Entities.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        
        public string GenreName { get; set; }
        
        public string? GenreUrl { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
