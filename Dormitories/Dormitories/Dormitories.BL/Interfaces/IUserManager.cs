using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity;

namespace Dormitories.BL.Interfaces
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<IdentityResult> AddToRolesAsync(long userId, params string[] roles);

        Task<User> FindAsync(string userName, string password);

        Task<User> FindAsync(UserLoginInfo login);

        Task<IdentityResult> AddLoginAsync(long userId, UserLoginInfo login);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        ClaimsIdentity CreateExternalIdentity(User user, string authenticationType);

        Task<User> FindByEmailAsync(string email);

        Task<IList<string>> GetRolesAsync(long userId);

        Task<IdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
    }
}
