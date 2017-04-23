using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class FloorConfiguration : EntityTypeConfiguration<Floor>
    {
        public FloorConfiguration()
        {
            ToTable("dbo.Floors");

            HasKey(x => x.Id);

            Property(x => x.Number).IsRequired();
            
            HasMany(x => x.Blocks)
                .WithRequired(y => y.Floor)
                .HasForeignKey(x => x.FloorId);


        }
    }
}
