﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Dormitory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Addres { get; set; }
        public int Number { get; set; }
        public int Comendant_id { get; set; }
    }
}
