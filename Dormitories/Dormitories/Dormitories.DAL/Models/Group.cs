using System.Collections.Generic;

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
