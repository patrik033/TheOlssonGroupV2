using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TheOlssonGroup.Repository.Repositorys;

namespace TheOlssonGroup.Server.ContextFactory
{
    public class OlssonContextFactory : IDesignTimeDbContextFactory<OlssonContext>
    {
        public OlssonContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<OlssonContext>()
                .UseSqlServer(configuration.GetConnectionString("AzureServer"),
                b => b.MigrationsAssembly("TheOlssonGroup.Server"));

            return new OlssonContext(builder.Options);
        }
    }
}
