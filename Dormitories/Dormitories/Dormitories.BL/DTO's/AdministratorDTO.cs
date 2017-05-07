namespace Dormitories.BL.DTO_s
{
    public class AdministratorDTO
    {
        public long Id { get; set; }
        public int? DormitoryId { get; set; }
        public int? FacultyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
