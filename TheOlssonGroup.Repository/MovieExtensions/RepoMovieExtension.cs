using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOlssonGroup.Entities.DatabaseModels;

namespace TheOlssonGroup.Repository.MovieExtensions
{
    public static class RepoMovieExtension
    {
        public static IQueryable<Movie> Search(this IQueryable<Movie> movies, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return movies;
            }
            var low = searchTerm.ToLower();
            return movies.Where(z => z.Title.ToLower().Contains(low) || z.Genre.GenreName.ToLower().Contains(low));
        }
            
    }
}
