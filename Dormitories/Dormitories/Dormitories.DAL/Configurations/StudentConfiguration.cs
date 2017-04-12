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
    public  class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Students");

            HasKey(x => x.Id);

            Property(x => x.IsAssigned).IsRequired();
            Property(x => x.IsRegistered).IsRequired();
            Property(x => x.StudyYear).IsRequired();    
        }
    }
}
