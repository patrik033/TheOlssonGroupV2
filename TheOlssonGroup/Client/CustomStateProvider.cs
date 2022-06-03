using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TheOlssonGroup.Shared.Identity
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomStateProvider(ILocalStorageService localStorage,HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //get the auth token from the localstorage
            string token = await _localStorage.GetItemAsStringAsync("token");
            //if there's no token set new claimsidentity
            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                //Bearer = name for the token
                try
                {
                    //try to parse if there's an auth token in the cart and get the claims
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                    //set the token to the bearer string
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token.Replace("\"",""));
                }
                catch
                {
                    //if not create a new user
                    await _localStorage.RemoveItemAsync("token");
                    identity = new ClaimsIdentity();
                }
            }
            //create an user with empty identity
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            //notify the app that the user is not authorized
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }


        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

    }
}
