using P06Library.Shared;
using P06Library.Shared.Auth;

namespace P05Library.API.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(string email, string password);

        Task<ServiceResponse<int>> Register(User user, string password);

        Task<bool> UserExists(string email);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        
        Task<ServiceResponse<string>> LoginByFacebook(string code, string redirect_uri);
    }
}
