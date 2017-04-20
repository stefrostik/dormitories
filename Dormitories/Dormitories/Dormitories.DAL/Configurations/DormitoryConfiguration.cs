using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public class DormitoryConfiguration : EntityTypeConfiguration<Dormitory>
    {
        public DormitoryConfiguration()
        {
            ToTable("dbo.Dormitories");

            HasKey(x => x.Id);

            Property(x => x.Number).IsRequired();
            Property(x => x.Description).IsRequired();
            Property(x => x.Address).IsRequired();

            HasMany(x => x.Floors)
                .WithRequired(x => x.Dormitory)
                .HasForeignKey(x => x.DormitoryId);

            HasMany(x => x.Administrators)
                .WithOptional(x => x.Dormitory)
                .HasForeignKey(x => x.DormitoryId);

        }
    }
}
