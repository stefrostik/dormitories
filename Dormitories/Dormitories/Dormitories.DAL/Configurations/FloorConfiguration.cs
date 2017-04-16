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
    public  class FloorConfiguration : EntityTypeConfiguration<Floor>
    {
        public FloorConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Floors");

            HasKey(x => x.Id);

            Property(x => x.number).IsRequired();
            
            HasMany(x => x.Blocks)
                .WithRequired(y => y.Floor)
                .HasForeignKey(x => x.FloorId);


        }
    }
}
