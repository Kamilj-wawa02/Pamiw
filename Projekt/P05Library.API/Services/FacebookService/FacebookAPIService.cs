using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using P05Library.API.Models;
using P06Library.Shared;
using P06Library.Shared.Auth;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace P05Library.API.Services.AuthService
{

    public class FacebookAPIService : IFacebookAPIService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookAPIService(DataContext context, IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _config = config;
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessToken(string code, string redirect_uri)
        {
            var tokenEndpoint = "https://graph.facebook.com/v12.0/oauth/access_token";
            var clientId = _config.GetSection("AppSettings:FacebookClientID").Value;
            var clientSecret = _config.GetSection("AppSettings:FacebookClientSecret").Value;
            //var redirect_uri = "https://localhost:7230/api/Auth/login-by-facebook-redirection";

            // Wykonaj żądanie do uzyskania access token
            var requestUrl = $"{tokenEndpoint}?client_id={clientId}&client_secret={clientSecret}&code={code}&redirect_uri={redirect_uri}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(requestUrl);
                var tokenResponse = JsonConvert.DeserializeObject<FacebookAuthDTO>(response);
                return tokenResponse?.AccessToken;
            }
        }


        public async Task<FacebookUserDataDTO> GetFacebookUserData(string accessToken)
        {
            var facebookGraphApiUrl = String.Format(_config.GetSection("AppSettings:FacebookGraphApiUrl").Value, accessToken);

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetStringAsync(facebookGraphApiUrl);
                var facebookUser = JsonConvert.DeserializeObject<FacebookUserDataDTO>(response);
                return facebookUser;
            }
        }

    }
}
