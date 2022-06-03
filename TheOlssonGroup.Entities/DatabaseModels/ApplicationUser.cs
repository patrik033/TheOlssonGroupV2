
using Microsoft.AspNetCore.Identity;

namespace TheOlssonGroup.Entities.DatabaseModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
