using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Total_places { get; set; }
        public int Faculty_id { get; set; }
        public int Block_id { get; set; }
    }
}
