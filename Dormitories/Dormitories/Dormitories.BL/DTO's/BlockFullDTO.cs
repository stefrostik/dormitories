using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class BlockFullDTO
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public ICollection<RoomDTO> Rooms { get; set; }
    }
}
