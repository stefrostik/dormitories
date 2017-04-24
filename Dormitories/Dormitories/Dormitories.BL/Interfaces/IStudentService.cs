using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IStudentService
    {
        ICollection<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int id);
        bool UpdateStudent(StudentDTO student);
        bool DeleteStudent(int id);
        bool AddStudent(StudentDTO student);
    }
}
