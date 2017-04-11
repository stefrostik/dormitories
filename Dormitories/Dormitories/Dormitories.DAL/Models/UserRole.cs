using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
            Id = 1;
            name = "first";
        }
        
    }
}
