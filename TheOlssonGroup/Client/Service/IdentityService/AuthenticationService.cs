using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TheOlssonGroup.Entities.DatabaseModels;
using TheOlssonGroup.Entities.Identity.CreataUsers;

namespace BlazorHostedAuth.Client.Services.IdentityService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(HttpClient httpClient,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<SignInResponseDto> Login(SignInRequestDto signInRequest)
        {

            var content = JsonConvert.SerializeObject(signInRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/v1/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignInResponseDto>(contentTemp);


            if (response.IsSuccessStatusCode)
            {
                // store the token and userdto in the localstorage, set the default authorization with the bearer token => will be passed with all requests
                // and setting authseccuessful to be true
                await _localStorageService.SetItemAsync(StaticDetails.Local_Token, result.Token);
                await _localStorageService.SetItemAsync(StaticDetails.Local_UserDetails, result.UserDto);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new SignInResponseDto() { IsAuthSuccessful = true };
            }
            else
            {
                return result;
            }
        }
        public async Task Logout()
        {
            //remove everything from the login so the user is no longer authorized
            await _localStorageService.RemoveItemAsync(StaticDetails.Local_Token);
            await _localStorageService.RemoveItemAsync(StaticDetails.Local_UserDetails);
            _httpClient.DefaultRequestHeaders.Authorization = null;

        }

        public async Task<SignUpResponseDto> RegisterUser(SignUpRequestDto signUpRequest)
        {
            var content = JsonConvert.SerializeObject(signUpRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/v1/account/signup", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignUpResponseDto>(contentTemp);


            if (response.IsSuccessStatusCode)
            {
                return new SignUpResponseDto() { IsRegistrationSuccessful = true };
            }
            else
            {
                return new SignUpResponseDto() { IsRegistrationSuccessful = false, Errors = result.Errors };
            }
        }
    }
}
