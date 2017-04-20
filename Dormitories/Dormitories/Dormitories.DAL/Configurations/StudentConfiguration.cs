using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("dbo.Students");
        }
    }
}
