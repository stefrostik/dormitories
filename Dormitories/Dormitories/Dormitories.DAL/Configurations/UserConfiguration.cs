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
    public  class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            //todo: ivestigate EF fluent api, EntityTypeConfiguration methods
            ToTable("dbo.Users");

            HasKey(x => x.Id);

            Property(x => x.Login).IsRequired();
            Property(x => x.Password).IsRequired();
            
        }
    }
}
