using System.ComponentModel.DataAnnotations;

namespace TheOlssonGroup.Entities.DatabaseModels
{
    public class Genre
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }
        public string? GenreUrl { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
