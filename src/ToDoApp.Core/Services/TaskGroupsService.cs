using System.Collections.Generic;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TaskGroupsService : ITaskGroupsServiceInterface
    {
        public IEnumerable<TaskGroup> GetAllTaskGroups()
        {
            throw new System.NotImplementedException();
        }

        public int CreateTaskGroup(CreateTaskGroupRequest request)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTaskGroupById(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTaskGroupName(int groupId, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}