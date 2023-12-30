using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using P12MAUI.Client.ViewModels;
using P12MAUI.Client;
using System.IdentityModel.Tokens.Jwt;

namespace P12MAUI.Client.Services.CustomAuthStateProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = AppCurrentResources.Token;

            var identity = new ClaimsIdentity();
            //_httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    //identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    //Debug.WriteLine("THIS TOKEN IS VALID --------------------------------------------");


                    identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    Debug.WriteLine("Checking token: '" + authToken + "'");

                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(authToken) as JwtSecurityToken;

                    if (jsonToken != null)
                    {
                        var expirationDate = jsonToken.ValidTo;
                        Debug.WriteLine($">>> Token is valid until: {expirationDate}, current date: {DateTime.Now.ToUniversalTime()}");

                        if (DateTime.Now.ToUniversalTime() > expirationDate)
                        {
                            Debug.WriteLine($">>> THE TOKEN HAS EXPIRED!!!");
                            throw new Exception("Expired");
                        }
                    }
                    else
                    {
                        throw new Exception("IncorrectToken");
                    }

                    //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    Debug.WriteLine("THIS TOKEN IS VALID --------------------------------------------");
                }
                catch (Exception e)
                {
                    Debug.WriteLine("THIS TOKEN IS INVALID ===========================================");
                    AppCurrentResources.SetToken("");
                    identity = new ClaimsIdentity();
                }
            }
            else
            {
                Debug.WriteLine("THE USER ISN'T LOGGED IN");
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
