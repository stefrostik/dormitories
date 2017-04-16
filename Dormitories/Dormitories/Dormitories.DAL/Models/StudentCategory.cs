using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class StudentCategory
    {
        public StudentCategory()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public string description { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
