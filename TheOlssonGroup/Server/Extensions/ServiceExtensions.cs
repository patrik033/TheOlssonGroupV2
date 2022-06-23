using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using TheOlssonGroup.Repository.Repositorys;



namespace TheOlssonGroup.Server.Extensions
{
    public static class ServiceExtensions
    {
        //CORS (Cross-origin Resorce sharing) ger eller begränars rättigheter beroende på domäner.
        //vill jag kunna skicka förfrågningar till vår application från andra domäner, måste jag ha
        //Configurerat CORS
        /// <summary>
        /// Denna extensions tillåter alla requests som blir skickade till vårat API
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination"));
            });

        /// <summary>
        /// Versioning for the API
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureApiVersioning(this IServiceCollection services) =>
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

     
        /// <summary>
        /// Configure the sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSqlContextOlsson(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<OlssonContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("AzureServer")));
    }
}
