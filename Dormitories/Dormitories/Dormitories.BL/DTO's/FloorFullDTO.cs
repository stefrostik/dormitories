﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.BL.DTO_s
{
    public class FloorFullDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int DormitoryId { get; set; }
        public ICollection<BlockDTO> Blocks { get; set; }
    }
}
