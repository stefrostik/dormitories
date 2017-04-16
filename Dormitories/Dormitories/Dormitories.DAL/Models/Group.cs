using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
