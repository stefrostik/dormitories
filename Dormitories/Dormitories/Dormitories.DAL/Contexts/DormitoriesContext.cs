using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL.Mappings;
using Dormitories.DAL.Models;

namespace Dormitories.DAL
{
    public class DormitoriesContext: DbContext
    {
        public DormitoriesContext() : base("name = Dormitories"){}

        //todo: add all dbsets, all models
        public  virtual DbSet<Dormitory> Dormitories { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCategory> StudentCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new FacultyConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new DormitoryConfiguration());
            modelBuilder.Configurations.Add(new AdminstratorConfiguration());
            modelBuilder.Configurations.Add(new BlockConfiguration());
            modelBuilder.Configurations.Add(new FloorConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new StudentCategoryConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());

            //todo:add all configurations
        }
    }
}
