using TheOlssonGroup.Entities.Identity.CreataUsers;

namespace BlazorHostedAuth.Client.Services.IdentityService
{
    public interface IAuthenticationService
    {
        Task<SignUpResponseDto> RegisterUser(SignUpRequestDto signUpRequestDto);
        Task<SignInResponseDto> Login(SignInRequestDto signInRequestDto);
        Task Logout();
    }
}
