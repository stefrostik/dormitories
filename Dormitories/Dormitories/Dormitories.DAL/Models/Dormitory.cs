using System.Collections.Generic;

namespace Dormitories.DAL.Models
{
    public class Dormitory
    {
        public Dormitory()
        {
            Floors = new HashSet<Floor>();
            Administrators = new HashSet<Administrator>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public int ComendantId { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }

    }
}
