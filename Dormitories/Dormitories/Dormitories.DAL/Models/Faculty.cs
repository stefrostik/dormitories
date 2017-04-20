using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Faculty
    {
        public Faculty()
        {
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
