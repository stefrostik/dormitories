using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class RoomFullDTO
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int TotalPlaces { get; set; }
        public int BlockId { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
