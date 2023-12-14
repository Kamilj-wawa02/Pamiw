using Microsoft.AspNetCore.WebUtilities;
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

        public string LoginWithFacebookFormRedirection(string redirect_uri)
        {
            return string.Format(_appSettings.BaseAPIUrl + "/" + "api/Auth/login-by-facebook-form-redirection?redirect_uri={0}", redirect_uri);

            //var result = 
            //await _httpClient.GetAsync(address);

            //var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            //return data;
        }

        public string LoginWithFacebookGetAccessToken(string redirect_uri, string code)
        {
            return string.Format(_appSettings.BaseAPIUrl + "/" + "api/Auth/login-by-facebook-get-access-token?redirect_uri={0},code={1}", redirect_uri, code);
        }

            public async Task<ServiceResponse<string>> LoginWithFacebook(string code, string redirect_uri)
        {
            var address = _appSettings.BaseAPIUrl + "/" + _appSettings.FacebookLoginEndpoint + "?code=" + code + "&redirect_uri=" + redirect_uri;
            var result = await _httpClient.GetAsync(address);
            var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            return data;
        }

        /*
            public async Task<ServiceResponse<string>> LoginWithFacebook()
        {
            var address = _appSettings.BaseAPIUrl + "/" + _appSettings.FacebookLoginEndpoint;

            var result = await _httpClient.GetAsync(address);

            var data = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            return data;
        }
        */

        public string GetLoginWithFacebook()
        {
            return _appSettings.BaseAPIUrl + "/" + _appSettings.FacebookLoginEndpoint;
        }

        public async Task<string> ProcessUri(string uri, string redirectionUri)
        {
            var query = uri.Split("?")[1];

            if (query.Contains("#"))
            {
                query = query.Substring(0, query.IndexOf("#"));
            }

            QueryHelpers.ParseQuery(query).TryGetValue("code", out var code);

            var result = await LoginWithFacebook(code, redirectionUri);
            if (result.Success)
            {
                return result.Data;
            }

            return "";
        }

    }
}
