using System.Data.Entity.ModelConfiguration;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Configurations
{
    public  class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration()
        {
            ToTable("dbo.Rooms");

            HasKey(x => x.Id);

            Property(x => x.TotalPlaces).IsRequired();

            HasMany(x => x.Students)
                .WithOptional(x => x.Room)
                .HasForeignKey(x => x.RoomId);
        }
    }
}
