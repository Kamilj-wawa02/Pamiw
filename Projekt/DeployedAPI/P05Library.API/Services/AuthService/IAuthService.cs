using P05Library.API.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P05Library.API;

namespace P05Library.API.Services.AuthService
{
    public interface IAuthService
    {
        void SetAuthToken(string authToken);
        Task<ServiceResponse<string>> Login(string email, string password);

        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);

        Task<ServiceResponse<string>> LoginWithFacebook(string code, string redirect_uri);

        string GetLoginWithFacebook();

        string LoginWithFacebookFormRedirection(string redirect_uri);

        string LoginWithFacebookGetAccessToken(string redirect_uri, string code);

        Task<string> ProcessUri(string uri, string redirectionUri);

        Task<ServiceResponse<string>> LoginByFacebook(string code, string redirect_uri);

    }
}
