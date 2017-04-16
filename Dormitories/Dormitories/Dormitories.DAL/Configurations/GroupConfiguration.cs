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
    public  class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Groups");

            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired();

            HasMany(x => x.Students)
                .WithRequired(y => y.Group)
                .HasForeignKey(x => x.GroupId);

        }
    }
}
