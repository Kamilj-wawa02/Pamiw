using P06Library.Shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Library.Shared.Services.AuthService
{
    public interface IAuthService
    {
        void SetAuthToken(string authToken);
        Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDto);

        Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO);

        Task<ServiceResponse<bool>> ChangePassword(string newPassword);

        Task<ServiceResponse<string>> LoginWithFacebook(string code, string redirect_uri);

        string GetLoginWithFacebook();

        string LoginWithFacebookFormRedirection(string redirect_uri);

        string LoginWithFacebookGetAccessToken(string redirect_uri, string code);

        Task<string> ProcessUri(string uri, string redirectionUri);

    }
}
