using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class StudentCategory
    {
        public StudentCategory()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
