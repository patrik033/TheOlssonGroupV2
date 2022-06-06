global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.Components.Authorization;
global using TheOlssonGroup.Client;
global using TheOlssonGroup.Client.Service;
global using TheOlssonGroup.Client.Service.CartServiceClient;
global using TheOlssonGroup.Client.Service.Contratct;
using Blazored.Modal;
using BlazorHostedAuth.Client.Services;
using BlazorHostedAuth.Client.Services.IdentityService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TheOlssonGroup.Client.Service.AdminServices;
using TheOlssonGroup.Client.Service.EmailServiceClient;
using TheOlssonGroup.Client.Service.UserServiceClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//identity start
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
//Identity end
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<IMovieServiceClient, MovieServiceClient>();
builder.Services.AddScoped<IGenreServiceClient, GenreServiceClient>();
builder.Services.AddScoped<ICartServiceClient, CartServiceClient>();
builder.Services.AddScoped<IEmailServiceClient, EmailServiceClient>();
builder.Services.AddScoped<IUserServiceClient, UserServiceClient>();
builder.Services.AddOptions();

builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
