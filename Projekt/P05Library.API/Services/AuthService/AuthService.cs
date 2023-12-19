using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IFacebookAPIService _facebookAPIService;
        public AuthService(DataContext context, IConfiguration config, IFacebookAPIService facebookAPIService)
        {
            _context = context;
            _config = config;
            _facebookAPIService = facebookAPIService;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Password updated successfully.",
                Success = true
            };
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            Debug.WriteLine("Logging in user " + email);

            var response = new ServiceResponse<string>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password.";
            }
            else
            {
                response.Data = CreateToken(user);
                response.Success = true;
                response.Message = "Login successful.";
            }


            return response;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Email),
                 new Claim(ClaimTypes.Role, user.Role),
                 new Claim("DateCreated", user.DateCreated.ToString()),
             };

            string secret = _config.GetSection("AppSettings:Token").Value;
            Debug.WriteLine("Signing with secret: " + secret);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                               claims: claims,
                               expires: DateTime.Now.AddDays(1),
                               signingCredentials: creds
                  );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            Debug.WriteLine("Created token: '" + tokenHandler + "'");

            return tokenHandler;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            Debug.WriteLine("Registering " + user.Email);

            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            // create password hash and salt
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // assign hash and salt to user
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // add user to db
            await _context.Users.AddAsync(user);
            // save changes
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Success = true, Data = user.Id, Message = "Registration successful!" };

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // using statement to dispose of IDisposable objects
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // generate random salt
                passwordSalt = hmac.Key;
                // generate hash
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<string>> LoginByFacebook(string code, string redirect_uri)
        {
            var response = new ServiceResponse<string>();

            if (string.IsNullOrEmpty(code))
            {
                response.Success = false;
                response.Message = "Invalid code.";
                return response;
            }

            // Otrzymaliśmy kod, na jego podstawie uzyskujemy access_token wykorzystując przy tym ID i Secret aplikacji na Facebooku
            var accessToken = await _facebookAPIService.GetAccessToken(code, redirect_uri);
            if (string.IsNullOrEmpty(code))
            {
                response.Success = false;
                response.Message = "Couldn't obtain the AccessToken.";
                return response;
            }

            // Pozyskujemy dane z Facebooka na podstawie wartości access_token
            var data = await _facebookAPIService.GetFacebookUserData(accessToken);

            if (data == null)
            {
                response.Success = false;
                response.Message = "Couldn't obtain the account data by the AccessToken.";
                return response;
            }

            var name = data.Name;
            var email = data.Email;
            if (string.IsNullOrEmpty(email))
            {
                response.Success = false;
                response.Message = "Couldn't get the account email (propable cause: No Permission).";
                return response;
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                user = CreateExternalUser(email, name);
            }

            response.Data = CreateToken(user);
            response.Success = true;
            response.Message = "Login with Facebook successful.";

            return response;
        }

        protected User CreateExternalUser(string email, string name)
        {
            var user = new User();
            user.Email = email;
            user.Username = name.Replace(" ", "_");

            //CreatePasswordHash(email, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = new byte[0]; //passwordHash;
            user.PasswordSalt = new byte[0]; //passwordSalt;

            return user;
        }

    }
}
