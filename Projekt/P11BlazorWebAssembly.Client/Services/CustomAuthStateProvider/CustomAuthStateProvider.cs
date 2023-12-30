using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace P11BlazorWebAssembly.Client.Services.CustomAuthStateProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

            var identity = new ClaimsIdentity();
            //_httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    authToken = authToken.Replace("\"", "");
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);


                    Console.WriteLine($">>> Reading token... " + authToken);

                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(authToken) as JwtSecurityToken;

                    Console.WriteLine($">>> Next...");

                    if (jsonToken != null)
                    {
                        var expirationDate = jsonToken.ValidTo;
                        Console.WriteLine($">>> Token is valid until: {expirationDate}, current date: {DateTime.Now.ToUniversalTime()}");

                        if (DateTime.Now.ToUniversalTime() > expirationDate)
                        {
                            Console.WriteLine($">>> THE TOKEN HAS EXPIRED!!!");
                            throw new Exception("Expired");
                        }
                    }
                    else
                    {
                        throw new Exception("IncorrectToken");
                    }

                    Console.WriteLine("THIS TOKEN IS VALID --------------------------------------------");
                }
                catch (Exception)
                {
                    Console.WriteLine("THIS TOKEN IS INVALID ===========================================");
                    await _localStorageService.RemoveItemAsync("authToken");
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;    
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
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
