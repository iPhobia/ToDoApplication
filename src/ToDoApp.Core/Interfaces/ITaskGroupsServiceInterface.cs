using System.Collections.Generic;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;

namespace ToDoApp.Core.Interfaces
{
    public interface ITaskGroupsServiceInterface
    {
        IEnumerable<TaskGroup> GetAllTaskGroups();
        int CreateTaskGroup(CreateTaskGroupRequest request);
        void DeleteTaskGroupById(int groupId);
        void UpdateTaskGroupName(int groupId, string newName);
    }
}