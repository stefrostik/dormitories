using System.Collections.Generic;
using System.Data.Entity;
using Dormitories.DAL.Configurations;
using Dormitories.DAL.Identity;
using Dormitories.DAL.Mappings;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dormitories.DAL.Contexts
{
    public class AuthorizationContext : IdentityDbContext<User, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AuthorizationContext()
            : base("name=Dormitories")
        {
            Database.SetInitializer<AuthorizationContext>(new CreateDatabaseIfNotExists<AuthorizationContext>());
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
            modelBuilder.Entity<CustomRole>().ToTable("dbo.Roles");
            modelBuilder.Entity<CustomUserRole>().ToTable("dbo.UserRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("dbo.UserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("dbo.UserClaims");

        }
    }
}
