﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Floor
    {
        //public Floor()
        //{
        //    Blocks = new HashSet<Block>();
        //}
        public int Id { get; set; }
        public int number { get; set; }
        public int DormitoryId { get; set; }
        //public virtual Dormitory Dormitory { get; set; }
        //public virtual ICollection<Block> Blocks { get; set; }
    }
}
