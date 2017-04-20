using Microsoft.AspNet.Identity.EntityFramework;

namespace Dormitories.DAL.Identity
{
    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole()
        {
        }

        public CustomRole(string name)
        {
            Name = name;
        }
    }
}
