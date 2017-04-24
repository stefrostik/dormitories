using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Dormitories.BL;

namespace Dormitories.WEB.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly IAuthenticationService _authService;

        public StudentsController(IStudentService studentService, IAuthenticationService authService)
        {
            _studentService = studentService;
            _authService = authService;
        }
        public ICollection<StudentDTO> Get()
        {
            return _studentService.GetAllStudents();
        }
        public StudentDTO Get(int id)
        {
            return _studentService.GetStudentById(id);
        }
        [HttpPut]
        public void Put([FromBody]StudentDTO student)
        {
            _studentService.UpdateStudent(student);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return true;

        }
        [HttpPost]
        public async Task<bool> Post([FromBody]StudentDTO student)
        {
            var newStudent = new UserRegisterDTO()
            {
                Password = "Aa123456",
                ConfirmPassword = "Aa123456",
                RoleName = "Student",
                CategoryId = student.CategoryId,
                FacultyId = student.FacultyId,
                GroupId = student.GroupId,
                RoomId = student.RoomId,
                StudentCardId = student.StudentCardId,
                StudyYear = student.StudyYear
            };
            IdentityResult result = await _authService.RegisterUser(newStudent);

            if (!result.Succeeded)
            {
                return false;
            }else

            return true;
        }

    }
}
