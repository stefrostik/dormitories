using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Floor
    {
        public Floor()
        {
            Blocks = new HashSet<Block>();
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public int DormitoryId { get; set; }
        public virtual Dormitory Dormitory { get; set; }
        public virtual ICollection<Block> Blocks { get; set; }
    }
}
