namespace Dormitories.BL
{
    public class UserRegisterDTO
    {
        public long Id { get; set; }
        public string StudentCardId { get; set; }
        public int? GroupId { get; set; }
        public int? FacultyId { get; set; }
        public int? RoomId { get; set; }
        public int StudyYear { get; set; }
        public int? CategoryId { get; set; }
        public string PhoneNumber { get; set; }
        public int? DormitoryId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
