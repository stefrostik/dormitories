using Dormitories.DAL.Interfaces;
using System;
using Dormitories.DAL.Models;
using Dormitories.DAL.Contexts;

namespace Dormitories.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DormitoriesContext context = new DormitoriesContext();

        private IGenericRepository<Administrator> administratorRepository;

        private IGenericRepository<Block> blockRepository;

        private IGenericRepository<Dormitory> dormitoryRepository;

        private IGenericRepository<Faculty> facultyRepository;

        private IGenericRepository<Floor> floorRepository;

        private IGenericRepository<Group> groupRepository;

        private IGenericRepository<Room> roomRepository;

        private IGenericRepository<Student> studentRepository;

        private IGenericRepository<StudentCategory> studentCategoryRepository;

        private IGenericRepository<User> userRepository;

        public IGenericRepository<Administrator> AdministratorRepository
        {
            get
            {
                if (administratorRepository == null)
                {
                    administratorRepository = new GenericRepository<Administrator>(context);
                }

                return administratorRepository;
            }
        }

        public IGenericRepository<Block> BlockRepository
        {
            get
            {
                if (blockRepository == null)
                {
                    blockRepository = new GenericRepository<Block>(context);
                }

                return blockRepository;
            }
        }

        public IGenericRepository<Dormitory> DormitoryRepository
        {
            get
            {
                if (dormitoryRepository == null)
                {
                    dormitoryRepository = new GenericRepository<Dormitory>(context);
                }

                return dormitoryRepository;
            }
        }

        public IGenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (facultyRepository == null)
                {
                    facultyRepository = new GenericRepository<Faculty>(context);
                }

                return facultyRepository;
            }
        }

        public IGenericRepository<Floor> FloorRepository
        {
            get
            {
                if (floorRepository == null)
                {
                    floorRepository = new GenericRepository<Floor>(context);
                }

                return floorRepository;
            }
        }

        public IGenericRepository<Group> GroupRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GenericRepository<Group>(context);
                }

                return groupRepository;
            }
        }

        public IGenericRepository<Room> RoomRepository
        {
            get
            {
                if (roomRepository == null)
                {
                    roomRepository = new GenericRepository<Room>(context);
                }

                return roomRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(context);
                }

                return userRepository;
            }
        }

        public IGenericRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new GenericRepository<Student>(context);
                }

                return studentRepository;
            }
        }

        public IGenericRepository<StudentCategory> StudentCategoryRepository
        {
            get
            {
                if (studentCategoryRepository == null)
                {
                    studentCategoryRepository = new GenericRepository<StudentCategory>(context);
                }

                return studentCategoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
