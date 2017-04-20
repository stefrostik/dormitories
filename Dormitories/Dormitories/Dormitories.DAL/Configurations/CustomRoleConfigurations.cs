using Dormitories.DAL.Identity;
using System.Data.Entity.ModelConfiguration;

namespace Dormitories.DAL.Configurations
{
    internal class CustomRoleConfigurations : EntityTypeConfiguration<CustomRole>
    {
        public CustomRoleConfigurations()
        {
            ToTable("dbo.Roles");

            HasKey(x => x.Id);
        }
    }
}

