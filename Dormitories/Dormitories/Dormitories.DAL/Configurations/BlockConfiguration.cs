using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Mappings
{
    public  class BlockConfiguration : EntityTypeConfiguration<Block>
    {
        public BlockConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Blocks");
            HasKey(x => x.Id);

            HasMany(x => x.Rooms)
                .WithRequired(x => x.Block)
                .HasForeignKey(x => x.BlockId);
        }
    }
}
