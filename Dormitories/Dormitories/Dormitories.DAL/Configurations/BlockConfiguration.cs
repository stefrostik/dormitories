using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class BlockConfiguration : EntityTypeConfiguration<Block>
    {
        public BlockConfiguration()
        {
            ToTable("dbo.Blocks");
            HasKey(x => x.Id);

            HasMany(x => x.Rooms)
                .WithRequired(y => y.Block)
                .HasForeignKey(x => x.BlockId);
        }
    }
}
