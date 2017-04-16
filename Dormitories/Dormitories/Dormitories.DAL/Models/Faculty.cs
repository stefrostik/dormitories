using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Faculty
    {
        public Faculty()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
