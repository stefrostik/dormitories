using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class StudentCategoryConfiguration : EntityTypeConfiguration<StudentCategory>
    {
        public StudentCategoryConfiguration()
        {
            ToTable("dbo.StudentCategories");

            HasKey(x => x.Id);

            Property(x => x.Description).IsRequired();

            HasMany(x => x.Students)
                .WithOptional(x => x.StudentCategory)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
