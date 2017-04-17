using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Administrator : User
    {
        public int? DormitoryId { get; set; }
        public virtual Dormitory Dormitory { get; set; }
    }
}
