using System.Collections.Generic;
using System.Web.Http;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;

namespace Dormitories.WEB.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public ICollection<StudentDTO> Get()
        {
            return _studentService.GetAllStudents();
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
        public bool Post([FromBody]StudentDTO student)
        {
            _studentService.AddStudent(student);
            return true;
        }

    }
}
