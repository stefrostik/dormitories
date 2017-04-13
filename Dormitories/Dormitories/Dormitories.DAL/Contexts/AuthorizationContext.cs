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
            : base("name=Dormitories")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new FacultyConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new DormitoryConfiguration());
            modelBuilder.Configurations.Add(new AdminstratorConfiguration());
            modelBuilder.Configurations.Add(new BlockConfiguration());
            modelBuilder.Configurations.Add(new FloorConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new StudentCategoryConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
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
