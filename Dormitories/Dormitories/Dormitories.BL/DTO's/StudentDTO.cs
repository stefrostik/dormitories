using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class StudentDTO
    {
        public long Id { get; set; }
        public string StudentCardId { get; set; }
        public int? GroupId { get; set; }
        public int? FacultyId { get; set; }
        public int? RoomId { get; set; }
        public int StudyYear { get; set; }
        public int? CategoryId { get; set; }

        public string Name { get; set; }
    }
}
