using Dormitories.BL.Interfaces;
using Dormitories.DAL.Contexts;
using Dormitories.DAL.Identity;

namespace Dormitories.BL.Identity
{
    public class DormitoriesIdentityProvider : IDormitoriesIdentityProvider
    {
        public AuthorizationContext Context => new AuthorizationContext();

        public IUserManager GetUserManager(AuthorizationContext context)
        {
            CustomUserStore store = new CustomUserStore(context);
            IUserManager manager = new CustomUserManager(store);

            return manager;
        }
    }
}
