using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Identity;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity;

namespace Dormitories.BL.Identity
{
    public class CustomUserManager : UserManager<User, long>, IUserManager
    {
        public CustomUserManager(CustomUserStore store)
            : base(store)
        {
            UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public ClaimsIdentity CreateExternalIdentity(User user, string authenticationType)
        {
            return this.CreateIdentity(user, authenticationType);
        }

        public Task<IdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword)
        {
            return base.ChangePasswordAsync(userId, currentPassword, newPassword);
        }
    }
}
