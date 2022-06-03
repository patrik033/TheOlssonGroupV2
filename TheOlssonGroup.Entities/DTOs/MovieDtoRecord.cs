using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOlssonGroup.Entities.DTOs
{
    public record MovieDtoRecord(
    int Id,
    string Title,
    float Rating,
    DateTime? ProductionYear,
    string? ShortDescription,
    string? LongDescription,
    string? PosterImageUrl,
    decimal Price,
    string GenreName,
    int GenreId,
    bool Featured);
}
