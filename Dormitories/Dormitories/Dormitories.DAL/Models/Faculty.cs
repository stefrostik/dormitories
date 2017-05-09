using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Faculty
    {
        public Faculty()
        {
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
            Groups = new HashSet<Group>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
