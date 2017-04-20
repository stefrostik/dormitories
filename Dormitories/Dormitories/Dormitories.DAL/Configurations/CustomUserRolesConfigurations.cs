using Dormitories.DAL.Identity;
using System.Data.Entity.ModelConfiguration;

namespace Dormitories.DAL.Configurations
{
    internal class CustomUserRolesConfigurations : EntityTypeConfiguration<CustomUserRole>
    {
        public CustomUserRolesConfigurations()
        {
            ToTable("dbo.UserRoles");

            HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
