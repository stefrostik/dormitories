using System.Collections.Generic;
using Dormitories.BL.DTO_s;

namespace Dormitories.BL.Interfaces
{
    public interface IGroupService
    {
        ICollection<GroupDTO> GetAllGroups();
        GroupDTO GetGroupById(int id);
        bool UpdateGroup(GroupDTO group);
        bool DeleteGroup(int id);
        bool AddGroup(GroupDTO group);
    }
}
