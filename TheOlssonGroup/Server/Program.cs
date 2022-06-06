using BlazorApp1.Server.APIHelper;
using BlazorHostedAuth.Server.APIHelper;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


using TheOlssonGroup.Contracts.Service.CartService;
using TheOlssonGroup.Contracts.Service.EmailService;
using TheOlssonGroup.Contracts.Service.GenreService;
using TheOlssonGroup.Contracts.Service.MovieService;
using TheOlssonGroup.Contracts.Service.StripeService;
using TheOlssonGroup.Contracts.Service.UserService;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Repository.Repositorys;
using TheOlssonGroup.Repository.Repositorys.Service.StripeServices;
using TheOlssonGroup.Repository.Service.CartService;
using TheOlssonGroup.Server.Extensions;
using TheOlssonGroup.Server.Service.EmailService;
using TheOlssonGroup.Server.Service.GenreService;
using TheOlssonGroup.Server.Service.MovieService;
using TheOlssonGroup.Server.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

//extensions
builder.Services.ConfigureCors();

//connectionstring
builder.Services.ConfigureSqlContextOlsson(builder.Configuration);
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.ConfigureApiVersioning();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IMoviePostService, MoviePostService>();
builder.Services.AddScoped<IEmailServiceServer, EmailServiceServer>();
builder.Services.AddScoped<IUserService, UserService>();



//identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<OlssonContext>();

//get section from appsettings for identity
var apiSettingsSection = builder.Configuration.GetSection("APISettings");
builder.Services.Configure<APISettings>(apiSettingsSection);


builder.Services.AddScoped<IEmailSender, EmailSenderAPI>();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();
app.UseSwaggerUI( options =>
{
//endpoint for versioning
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{ ForwardedHeaders = ForwardedHeaders.All });
app.UseRouting();
//added cors
app.UseCors("CorsPolicy");


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
