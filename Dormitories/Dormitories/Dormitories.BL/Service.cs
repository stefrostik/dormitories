using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL;
using Dormitories.DAL.Contexts;
using Dormitories.DAL.Models;

namespace Dormitories.BL
{
    public class Service
    {
        public void Test()
        {
            using (var ctx = new DormitoriesContext())
            {
                var drm1 = new Dormitory() {Id = 6, Number = 8, Address ="Ukraine", Description="descpription"};
                ctx.Dormitories.Add(drm1);
                ctx.SaveChanges();
            }

        }
        public void Test2()
        {
            using (var ctx = new DormitoriesContext())
            {
                //var user1 = new User() { Id = 1, Login = "log123", Password = "Aa123456" };
                //ctx.Users.Add(user1);
                //ctx.SaveChanges();
            }

        }
        public void Test3()
        {
            using (var ctx = new DormitoriesContext())
            {
                //var floor1 = new Floor() { Id = 2, number = 10 };
                //var drm1 = new Dormitory() { Id = 6, Number = 8, Address = "Ukraine", Description = "descpription" };
                //drm1.Floors = new List<Floor>();
                //drm1.Floors.Add(floor1);
                //ctx.Dormitories.Add(drm1);
                //ctx.SaveChanges();
            }
        }
        public void Test4()
        {
            //using (var ctx = new DormitoriesContext())
            //{
            //    var floor1 = new Floor() { Id = 2, number = 10 };

            //    ctx.Floors.Add(floor1);
            //    ctx.SaveChanges();
            //}
            using (var ctx = new AuthorizationContext())
            {
                Administrator admin = new Administrator()
                {
                   
                };
                Student student = new Student()
                {
                   
                    StudyYear = 2000
                };
                
                
               
                ctx.Users.Add(admin);
                ctx.Users.Add(student);
                ctx.SaveChanges();
            }
        }
    }
}
