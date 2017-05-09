using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
        {
            ToTable("dbo.Faculties");

            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired();

            HasMany(x => x.Rooms)
                .WithRequired(y => y.Faculty)
                .HasForeignKey(x => x.FacultyId);

            HasMany(x => x.Users)
                .WithOptional(y => y.Faculty)
                .HasForeignKey(x => x.FacultyId);

            HasMany(x => x.Groups)
                .WithRequired(y => y.Faculty)
                .HasForeignKey(y => y.FacultyId);

        }
    }
}
