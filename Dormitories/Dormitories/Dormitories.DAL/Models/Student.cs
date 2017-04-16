using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class Student : User
    {

        public int GroupId { get; set; }
        public bool IsAssigned { get; set; }
        public int RoomId { get; set; }
        public int StudyYear { get; set; }
        public int CategoryId { get; set; }
        public bool IsRegistered { get; set; }
        public virtual Group Group{ get; set; }
        //public virtual StudentCategory StudentCategory { get; set; }
        //public virtual Room Room { get; set; }

    }
}
