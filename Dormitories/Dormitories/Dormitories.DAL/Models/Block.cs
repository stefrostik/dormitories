using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Block
    {
        public Block()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
