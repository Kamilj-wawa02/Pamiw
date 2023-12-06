using P06Shop.Shared.Auth;
using P06Shop.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.AuthService
{
    public class AuthService : IAuthService
    {
    
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public AuthService(HttpClient httpClient, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;

        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login/", userLoginDto);

            var data =  await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            return data;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register/", userRegisterDTO);
            Console.WriteLine("Registration of user " + userRegisterDTO.Email + " returned " + await result.Content.ReadAsStringAsync());
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(string newPassword)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/change-password/", newPassword);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
        
        // do uzyskania ścieżki strony do logowania do Facebooka
        public string GetLoginWithFacebookAccessTokenRequest()
        {
            var appId = "884555979610977";
            //var appSecret = "d9913e56675654ab2293036f5a282075";
            var appRedirectUri = "https://localhost:7070";

            // Na podstawie: https://developers.facebook.com/docs/facebook-login/guides/access-tokens/
            var accessTokenRequest2 = "https://graph.facebook.com/oauth/access_token"
                                     + "?response_type=token"
                                     + $"&client_id={appId}"
                                     + $"&redirect_uri={appRedirectUri}";
            var accessTokenRequest = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={appRedirectUri}&response_type=token";

            Debug.WriteLine("Entering page: " + accessTokenRequest);

            return accessTokenRequest;
        }

        // do pozyskania tokena z naszego API z wykorzystaniem AccessTokena pozyskanego od Facebooka
        public async Task<ServiceResponse<string>> LoginByFacebookAccessToken(string accessToken)
        {
            Console.WriteLine($">>>>>>>>>>>>>>>>>>> {accessToken}");

            string accessToken2 = "test";

            var result = await _httpClient.PostAsJsonAsync("api/auth/login-by-facebook-access-token/", new FacebookAuthDTO { AccessToken = accessToken2 } );

            var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            return data;
        }

    }
}
