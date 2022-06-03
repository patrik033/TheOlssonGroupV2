
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Models;
using TheOlssonGroup.Repository.Configurations;

namespace TheOlssonGroup.Repository.Repositorys
{
    //for identity changed from dbcontext to identitydbcontext
    public class OlssonContext : IdentityDbContext
    {
        public OlssonContext(DbContextOptions<OlssonContext> options
           ) : base(options)
        {
        
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<ListOrdersDto> ListOrdersDto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Name = StaticDetails.Role_Customer,
                   NormalizedName = StaticDetails.Role_Customer.ToUpper()
               });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = StaticDetails.Role_Admin,
                    NormalizedName = StaticDetails.Role_Admin.ToUpper()
                });
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    UserName = "Admin@Olsson.com",
                    Email = "Admin@Olsson.com",
                    EmailConfirmed = true
                });
            base.OnModelCreating(modelBuilder);


        }
    }
}
