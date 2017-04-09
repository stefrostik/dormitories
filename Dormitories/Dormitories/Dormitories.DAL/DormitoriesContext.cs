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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new DormitoryConfiguration());
            //todo:add all configurations
        }
    }
}
