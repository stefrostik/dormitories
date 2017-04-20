using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Room
    {
        public Room()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public int TotalPlaces { get; set; }
        public int FacultyId { get; set; }
        public int BlockId { get; set; }
        public virtual Block Block { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
