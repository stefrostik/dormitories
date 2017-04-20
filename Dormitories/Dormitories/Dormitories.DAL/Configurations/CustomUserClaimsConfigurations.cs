using Dormitories.DAL.Identity;
using System.Data.Entity.ModelConfiguration;

namespace Dormitories.DAL.Configurations
{
    internal class CustomUserClaimsConfigurations : EntityTypeConfiguration<CustomUserClaim>
    {
        public CustomUserClaimsConfigurations()
        {
            ToTable("dbo.UserClaims");

            HasKey(x => x.Id);
        }
    }
}
