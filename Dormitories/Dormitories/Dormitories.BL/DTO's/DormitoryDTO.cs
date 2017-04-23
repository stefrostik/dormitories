using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class DormitoryDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public int Number { get; set; }
        public int ComendantId { get; set; }

    }
}
