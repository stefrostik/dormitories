using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.DAL.Identity;
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

        Task<bool> HasRegistered(UserLoginInfo info);

        Task<string> GetAllRolesJson(long userId);

        ICollection<RoleDTO> GetAllRoles();
    }
}
