using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOlssonGroup.Entities.DatabaseModels;

namespace TheOlssonGroup.Repository.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>

    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData
                (
                    new Genre
                    {
                        Id = 1,
                        GenreName = "Action",
                        GenreUrl = "action"
                    },
                    new Genre
                    {
                        Id = 2,
                        GenreName = "Sci-Fi",
                        GenreUrl = "sci-fi"
                    },
                    new Genre
                    {
                        Id = 3,
                        GenreName = "Drama",
                        GenreUrl = "drama"
                    },
                     new Genre
                     {
                         Id = 4,
                         GenreName = "Documentary",
                         GenreUrl = "documentary"
                     },
                     new Genre
                     {
                         Id = 5,
                         GenreName = "Comedy",
                         GenreUrl = "comedy"
                     },
                     new Genre
                     {
                         Id = 6,
                         GenreName = "Animé",
                         GenreUrl = "animé"
                     },
                     new Genre
                     {
                         Id = 7,
                         GenreName = "Horror",
                         GenreUrl = "horror"
                     },
                     new Genre
                     {
                         Id = 8,
                         GenreName = "Thriller",
                         GenreUrl = "thriller"
                     },
                     new Genre
                     {
                         Id = 9,
                         GenreName = "War",
                         GenreUrl = "war"
                     }
                );
        }
    }
}
