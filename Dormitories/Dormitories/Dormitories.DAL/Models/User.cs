using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Dormitories.DAL.Identity;

namespace Dormitories.DAL.Models
{
    public abstract class User : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int FacultyId { get; set; }


    }
}
