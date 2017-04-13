using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL.Mappings;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Dormitories.DAL.Identity;


namespace Dormitories.DAL
{
    public class AuthorizationContext : IdentityDbContext<User, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AuthorizationContext()
            : base("name=DormitoriesContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
            ConfigureIdentityTables(modelBuilder);
        }

        private void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomRole>().ToTable("Roles");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaims");
        }
    }
}
