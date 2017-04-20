using Dormitories.DAL;
using Dormitories.DAL.Contexts;

namespace Dormitories.BL.Interfaces
{
    public interface IDormitoriesIdentityProvider
    {
        AuthorizationContext Context { get; }

        IUserManager GetUserManager(AuthorizationContext context);
    }
}
