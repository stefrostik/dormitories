using Dormitories.DAL;

namespace Dormitories.BL.Interfaces
{
    public interface IDormitoriesIdentityProvider
    {
        AuthorizationContext Context { get; }

        IUserManager GetUserManager(AuthorizationContext context);
    }
}
