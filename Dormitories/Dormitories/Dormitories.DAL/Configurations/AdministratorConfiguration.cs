using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public class AdminstratorConfiguration : EntityTypeConfiguration<Administrator>
    {
        public AdminstratorConfiguration()
        {
            ToTable("dbo.Administrators");
        }
    }
}
