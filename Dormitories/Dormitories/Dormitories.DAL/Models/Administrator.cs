using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public int Dormitory_id { get; set; }
        public int Faculty_id { get; set; }
    }
}
