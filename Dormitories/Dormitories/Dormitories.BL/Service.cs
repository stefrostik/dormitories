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
                var drm1 = new Dormitory() {Id = 6, Num = 8};
                ctx.Dormitories.Add(drm1);
                ctx.SaveChanges();
            }

        }
    }
}
