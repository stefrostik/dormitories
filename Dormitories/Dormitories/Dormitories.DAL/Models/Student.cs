using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Faculty_id { get; set; }
        public int Group_id { get; set; }
        public bool Is_assigned { get; set; }
        public int Room_id { get; set; }
        public int Study_year { get; set; }
        public int Category_id { get; set; }
        public bool Is_registered { get; set; }

    }
}
