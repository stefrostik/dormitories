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
    public  class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Faculties");

            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired();

            HasMany(x => x.Rooms)
                .WithRequired(y => y.Faculty)
                .HasForeignKey(x => x.FacultyId);

            HasMany(x => x.Users)
                .WithOptional(y => y.Faculty)
                .HasForeignKey(x => x.FacultyId);

        }
    }
}
