using Dormitories.DAL.Contexts;
using Microsoft.AspNet.Identity.EntityFramework;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Identity
{
    public class CustomUserStore : UserStore<User, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(AuthorizationContext context)
            : base(context)
        {
        }
    }
}
