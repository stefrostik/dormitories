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
    public  class DormitoryConfiguration: EntityTypeConfiguration<Dormitory>
    {
        public DormitoryConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Dormitories");

            HasKey(x => x.Id);

            Property(x => x.Number).IsRequired();
            Property(x => x.Description).IsRequired();
            Property(x => x.Addres).IsRequired();

            HasMany(x => x.Floors)
                .WithRequired(x => x.Dormitory)
                .HasForeignKey(x => x.DormitoryId);

            //HasMany(x => x.Administrators)
            //    .WithRequired(x => x.Dormitory)
            //    .HasForeignKey(x => x.DormitoryId);

        }
    }
}
