using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Interfaces;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity;

namespace Dormitories.BL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuthenticationService _authService;
        public StudentService(IUnitOfWorkFactory uowFactory, IAuthenticationService authService )
        {
            _uow = uowFactory.Create();
            _authService = authService;

        }

        public ICollection<StudentDTO> GetAllStudents()
        {
            using (_uow)
            {
                return _uow.StudentRepository.Query().Select(d => new StudentDTO()
                {
                    Id = d.Id,
                    RoomId = d.RoomId,
                    CategoryId = d.CategoryId,
                    FacultyId = d.FacultyId,
                    GroupId = d.GroupId,
                    StudyYear = d.StudyYear,
                    StudentCardId = d.StudentCardId
                }).ToList();
            }
            
        }
        public StudentDTO GetStudentById(int id)
        {
            using (_uow)
            {
                return _uow.StudentRepository.Query().Select(d => new StudentDTO() {
                    Id = d.Id,
                    RoomId = d.RoomId,
                    CategoryId = d.CategoryId,
                    FacultyId = d.FacultyId,
                    GroupId = d.GroupId,
                    StudyYear = d.StudyYear,
                    StudentCardId = d.StudentCardId
                }).FirstOrDefault();         
            }    
        }

        public bool UpdateStudent(StudentDTO student)
        {
            using (_uow)
            {
                var tempStudent = _uow.StudentRepository.GetById(student.Id);
                tempStudent.RoomId = student.RoomId;
                tempStudent.CategoryId = student.CategoryId;
                tempStudent.FacultyId = student.FacultyId;
                tempStudent.GroupId = student.GroupId;
                tempStudent.StudyYear = student.StudyYear;
                tempStudent.StudentCardId = student.StudentCardId;
                _uow.StudentRepository.Update(tempStudent);
                _uow.Save();  
            }
            return true;
        }

        public bool DeleteStudent(int id)
        {
            using (_uow)
            {                
                var tempStudent = _uow.StudentRepository.GetById(id);
                _uow.StudentRepository.Delete(tempStudent);
                _uow.Save();
            }
            return true;
        }

        public bool AddStudent(StudentDTO student)
        {
            var newStudent = new UserRegisterDTO() {
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

            var result =  _authService.RegisterUser(newStudent).Result;

            return result.Succeeded;
        }

    }
}
