using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.DAL.Models;

namespace Dormitories.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Administrator> AdministratorRepository { get; }

        IGenericRepository<Block> BlockRepository { get; }

        IGenericRepository<Dormitory> DormitoryRepository { get; }

        IGenericRepository<Faculty> FacultyRepository { get; }

        IGenericRepository<Floor> FloorRepository { get; }

        IGenericRepository<Group> GroupRepository { get; }

        IGenericRepository<Room> RoomRepository { get; }

        IGenericRepository<Student> StudentRepository { get; }

        IGenericRepository<StudentCategory> StudentCategoryRepository { get; }

        IGenericRepository<User> UserRepository { get; }

        void Save();
    }
}
