using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("dbo.Groups");

            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired();

            HasMany(x => x.Students)
                .WithOptional(y => y.Group)
                .HasForeignKey(x => x.GroupId);

        }
    }
}
