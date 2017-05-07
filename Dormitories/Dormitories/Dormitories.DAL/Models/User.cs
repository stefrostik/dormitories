using Microsoft.AspNet.Identity.EntityFramework;
using Dormitories.DAL.Identity;

namespace Dormitories.DAL.Models
{
    public abstract class User : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FullName { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
