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

    public interface IFacebookAPIService
    {
        Task<string> GetAccessToken(string code, string redirect_uri);

        Task<FacebookUserDataDTO> GetFacebookUserData(string accessToken);
    }
}
