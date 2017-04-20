using Dormitories.DAL.Contexts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dormitories.DAL.Identity
{
    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(AuthorizationContext context)
            : base(context)
        {
        }
    }
}
