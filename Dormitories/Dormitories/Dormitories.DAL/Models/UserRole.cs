using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitories.DAL.Models
{
    public class UserRole
    {
        public ICollection<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string name { get; set; }
    }
}
