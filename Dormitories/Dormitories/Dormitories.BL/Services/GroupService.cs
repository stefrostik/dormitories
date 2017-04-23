using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Interfaces;
using Dormitories.DAL.Models;

namespace Dormitories.BL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;
        public GroupService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public ICollection<GroupDTO> GetAllGroups()
        {
            var groups = new List<GroupDTO>();

            using (_uow)
            {
                groups = _uow.GroupRepository.Query().Select(d => new GroupDTO()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList();
            }

            return groups;
        }
        public GroupDTO GetGroupById(int id)
        {
            using (_uow)
            {
                return _uow.GroupRepository.Query().Select(d => new GroupDTO()
                {
                    Id = d.Id,
                    Name = d.Name
                }).FirstOrDefault();
            }
        }

        public bool UpdateGroup(GroupDTO group)
        {
            using (_uow)
            {
                var tempGroup = _uow.GroupRepository.GetById(group.Id);
                tempGroup.Name = group.Name;

                _uow.GroupRepository.Update(tempGroup);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteGroup(int id)
        {
            using (_uow)
            {
                var tempGroup = _uow.GroupRepository.GetById(id);
                _uow.GroupRepository.Delete(tempGroup);
                _uow.Save();
            }
            return true;
        }

        public bool AddGroup(GroupDTO group)
        {
            using (_uow)
            {
                Group tempGroup = new Group();
                tempGroup.Name = group.Name;
                _uow.GroupRepository.Insert(tempGroup);
                _uow.Save();
            }
            return true;
        }
    }
}
