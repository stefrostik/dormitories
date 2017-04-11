using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL;
using Dormitories.DAL.Models;

namespace Dormitories.BL
{
    public class Service
    {
        public void Test()
        {
            using (var ctx = new DormitoriesContext())
            {
                var drm1 = new Dormitory() {Id = 6, Number = 8};
                ctx.Dormitories.Add(drm1);
                ctx.SaveChanges();
            }

        }
        public void Test2()
        {
            using (var ctx = new DormitoriesContext())
            {
                var user1 = new User() { Id = 1, Login = "log123", Password = "Aa123456" };
                ctx.Users.Add(user1);
                ctx.SaveChanges();
            }

        }
    }
}
