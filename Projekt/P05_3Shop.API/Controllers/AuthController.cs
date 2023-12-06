using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P05Shop.API.Services.AuthService;
using P06Shop.Shared;
using P06Shop.Shared.Auth;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IAuthService authService, IHttpClientFactory httpClientFactory)
        {
            this._authService = authService;
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet("Secret"), Authorize]
        public string SecretText()
        {
            return "secret";
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO userLoginDTO)
        {
            var response = await _authService.Login(userLoginDTO.Email, userLoginDTO.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO userRegisterDTO)
        {
            Console.WriteLine("Console -> New register request in API of user " + userRegisterDTO.Email);
            Debug.WriteLine("Debug -> New register request in API of user " + userRegisterDTO.Email);

            var user = new User()
            {
                Email = userRegisterDTO.Email,
                Username = userRegisterDTO.Username
            };

            var response = await _authService.Register(user, userRegisterDTO.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login-with-google")]
        public async Task<ActionResult<ServiceResponse<int>>> LoginWithGoogle(UserRegisterDTO userRegisterDTO)
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = "/" });
            return Ok();
        }


        [HttpPost("login-by-facebook-access-token")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebookAccessToken([FromBody] FacebookAuthDTO facebookAuthDTO)
        {
            var response = await _authService.LoginByFacebookAccessToken(facebookAuthDTO.AccessToken);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }




        [HttpGet("login-by-facebook")] // https://localhost:7230/api/Auth/login-by-facebook
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebook()
        {
            var appId = "884555979610977";
            var redirectUri = "https://localhost:7230/api/Auth/login-by-facebook-redirection";
            var facebookLoginUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&scope=email&response_type=code";

            return Redirect(facebookLoginUrl);
        }

        [HttpGet("login-by-facebook-redirection")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebookRedirection([FromQuery] string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var accessToken = await GetAccessToken(code);

                var data = await GetFacebookUserData(accessToken);

                /*
                var response = await _authService.LoginByFacebookAccessToken("");
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
                */

                return Ok(">>>>>>>> CODE: " + code + ">>>>>>>> access_token: " + accessToken + ">>>>>>>> Name: " + data.Name + ", Email: " + data.Email + ", Id: " + data.Id);
            }
            else
            {
                Debug.WriteLine(">>>>>>>>>>>>>>>>>>>> " + "NO CODE!!!");
                // Tutaj obsłuż błąd autentykacji
                //return RedirectToAction("Login", "Account");
                return Ok("No code!");
            }
        }

        private async Task<string> GetAccessToken(string code)
        {
            var tokenEndpoint = "https://graph.facebook.com/v12.0/oauth/access_token";
            var clientId = "884555979610977";
            var clientSecret = "d9913e56675654ab2293036f5a282075";
            var redirectUri = "https://localhost:7230/api/Auth/login-by-facebook-redirection";

            // Wykonaj żądanie do uzyskania access token
            var requestUrl = $"{tokenEndpoint}?client_id={clientId}&client_secret={clientSecret}&code={code}&redirect_uri={redirectUri}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(requestUrl);
                var tokenResponse = JsonConvert.DeserializeObject<FacebookTokenResponse>(response);
                return tokenResponse?.AccessToken;
            }
        }

        public class FacebookTokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }

        private async Task<FacebookUserData> GetFacebookUserData(string accessToken)
        {
            var facebookGraphApiUrl = "https://graph.facebook.com/v12.0/me?fields=id,email,name&access_token=" + accessToken;

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetStringAsync(facebookGraphApiUrl);

                var facebookUser = JsonConvert.DeserializeObject<FacebookUserData>(response);

                return facebookUser;
            }
        }

        public class FacebookUserData
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
