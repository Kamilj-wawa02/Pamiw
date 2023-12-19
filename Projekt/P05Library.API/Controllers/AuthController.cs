using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P05Library.API.Services.AuthService;
using P06Library.Shared;
using P06Library.Shared.Auth;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Claims;

namespace P05Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IFacebookAPIService _facebookAPIService;
        private readonly IConfiguration _config;
        

        public AuthController(IAuthService authService, IFacebookAPIService facebookAPIService, IConfiguration config)
        {
            this._authService = authService;
            this._facebookAPIService = facebookAPIService;
            this._config = config;
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

        /*
        // https://localhost:7230/api/Auth/login-by-facebook?redirectionPage=https%3A%2F%2Flocalhost%3A7230
        [HttpGet("login-by-facebook")] // https://localhost:7230/api/Auth/login-by-facebook
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebook([FromQuery] string redirectionPage)
        {
            var appId = _config.GetSection("AppSettings:FacebookClientID").Value;
            var redirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/Auth/login-by-facebook-redirection"; // "https://localhost:7230/api/Auth/login-by-facebook-redirection";
            // Dodaję dodatkowe ustawienie library_redirect_uri do przekazania API na jaką stronę mamy przekierować odpowiedź
            if (redirectionPage != null)
            {
                redirectUri = redirectUri + $"?library_redirect_uri={redirectionPage}";
            }
            
            var facebookLoginUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&scope=email&response_type=code";

            return Redirect(facebookLoginUrl);
        }
        */

        [HttpGet("login-by-facebook-form-redirection")] // https://localhost:7230/api/Auth/login-by-facebook
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebookFormRedirection([FromQuery] string redirect_uri = "")
        {
            var appId = _config.GetSection("AppSettings:FacebookClientID").Value;
            var facebookLoginUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={redirect_uri}&scope=email&response_type=code";
            return Redirect(facebookLoginUrl);
        }

        [HttpGet("login-by-facebook-test")] // https://localhost:7230/api/Auth/login-by-facebook
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebookTest()
        {
            var appId = _config.GetSection("AppSettings:FacebookClientID").Value;
            var redirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/Auth/login-by-facebook-redirection"; // "https://localhost:7230/api/Auth/login-by-facebook-redirection";
            var facebookLoginUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&scope=email&response_type=code";

            return Redirect(facebookLoginUrl);
        }



            [HttpGet("login-by-facebook")] // https://localhost:7230/api/Auth/login-by-facebook
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebook([FromQuery] string code, [FromQuery] string redirect_uri)
        {
            /*
            var appId = _config.GetSection("AppSettings:FacebookClientID").Value;
            var libraryRedirectUri = (library_redirect_uri != "" ? "%3Flibrary_redirect_uri%3D" + library_redirect_uri : "");
            libraryRedirectUri = ""; // WebUtility.UrlEncode(libraryRedirectUri);
            //return Ok(libraryRedirectUri);

            //libraryRedirectUri = "?library_redirect_uri=https://localhost:7230";

            var redirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/Auth/login-by-facebook-redirection{libraryRedirectUri}"; // "https://localhost:7230/api/Auth/login-by-facebook-redirection";
            var facebookLoginUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={appId}&redirect_uri={redirectUri}&scope=email&response_type=code";

            return Redirect(facebookLoginUrl);
            */

            var response = await _authService.LoginByFacebook(code, redirect_uri);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        // https://localhost:7230/api/Auth/login-by-facebook?library_redirect_uri=https%3A%2F%2Flocalhost%3A7230%2F
        [HttpGet("login-by-facebook-redirection")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginByFacebookRedirection([FromQuery] string code, [FromQuery] string library_redirect_uri = "")
        {
            //var response = await _authService.LoginByFacebook(code);

            return Ok();//("library_redirect_uri: " + library_redirect_uri + "     code: " + code + " response: " + response.Message);

            /*
            if (HttpContext.Request.Query.TryGetValue("library_redirect_uri", out var libraryRedirectUri))
            {
                response.Message = response.Message + "    library_redirect_uri: " + libraryRedirectUri;
                return Ok(response);
                //return Redirect(libraryRedirectUri + $"?Success={response.Success}&Message={response.Message}&Data={response.Data}");
            }
            else
            {
                response.Message = response.Message + "    library_redirect_uri: NONE!";
                if (!response.Success)
                {
                    return Ok(response); //BadRequest
                }
                return Ok(response);
            }

            */
            

            /*
            if (!string.IsNullOrEmpty(code))
            {
                // Otrzymaliśmy kod, na jego podstawie uzyskujemy access_token wykorzystując przy tym ID i Secret aplikacji na Facebooku
                var accessToken = await _facebookAPIService.GetAccessToken(code);

                // Pozyskujemy dane z Facebooka na podstawie wartości access_token
                var data = await _facebookAPIService.GetFacebookUserData(accessToken);

                
                //var response = await _authService.LoginByFacebookAccessToken("");
                //if (!response.Success)
                //{
                //    return BadRequest(response);
                //}
                //return Ok(response);

                return Ok(">>>>>>>> CODE: " + code + ">>>>>>>> access_token: " + accessToken + ">>>>>>>> Name: " + data.Name + ", Email: " + data.Email + ", Id: " + data.Id);
            }
            else
            {
                Debug.WriteLine(">>>>>>>>>>>>>>>>>>>> " + "NO CODE!!!");
                // Tutaj obsłuż błąd autentykacji
                //return RedirectToAction("Login", "Account");
                return BadRequest("No code!");
            }

            */
            
        }

    }
}
