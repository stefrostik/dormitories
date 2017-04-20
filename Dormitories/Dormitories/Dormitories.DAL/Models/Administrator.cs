namespace Dormitories.DAL.Models
{
    public class Administrator : User
    {
        public int? DormitoryId { get; set; }
        public virtual Dormitory Dormitory { get; set; }
    }
}
