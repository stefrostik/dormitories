using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class AdministratorDTO
    {
        public long Id { get; set; }
        public int? DormitoryId { get; set; }
        public int? FacultyId { get; set; }
    }
}
