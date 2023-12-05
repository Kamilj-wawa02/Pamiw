using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P05Shop.API.Services.AuthService;
using P06Shop.Shared;
using P06Shop.Shared.Auth;
using System.Diagnostics;
using System.Security.Claims;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpGet("Secret"), Authorize]
        public string SecretText()
        {
            return "secret";
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO userLoginDTO)
        {
            var response = await  _authService.Login(userLoginDTO.Email, userLoginDTO.Password);
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

    }
}
