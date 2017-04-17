using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity;

namespace Dormitories.BL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateAsync(User user);

        Task<IdentityResult> RegisterUser(UserRegisterDTO registerUserModel);

        Task<User> FindUser(string userName, string password);

        Task<ClaimsIdentity> CreateIdentity(User user, string authenticationType);

        Task<User> FindAsync(UserLoginInfo login);

        //ExternalLoginData GetExternalDataFromIdentity(ClaimsIdentity identity);

        //Task<IdentityResult> RegisterExternalAsync(ExternalLoginData data);

        //string GenerateLocalAccessTokenResponse(User user, OAuthAuthorizationServerOptions options);

        Task<bool> HasRegistered(UserLoginInfo info);

        Task<string> GetAllRolesJson(long userId);
    }
}
