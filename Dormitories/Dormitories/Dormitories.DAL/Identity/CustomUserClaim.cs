using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dormitories.DAL.Identity
{
    public class CustomUserClaim : IdentityUserClaim<long>
    {
    }
}
