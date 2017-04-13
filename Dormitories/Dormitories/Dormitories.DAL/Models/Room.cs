using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Room
    {
        //public Room()
        //{
        //    Students = new HashSet<Student>();
        //}
        public int Id { get; set; }
        public int TotalPlaces { get; set; }
        public int FacultyId { get; set; }
        public int BlockId { get; set; }
        //public virtual Block Block { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
    }
}
