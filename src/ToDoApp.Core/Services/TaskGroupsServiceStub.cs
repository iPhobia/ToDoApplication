using System.Collections.Generic;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TaskGroupsServiceStub : ITaskGroupsServiceInterface
    {
        public IEnumerable<TaskGroup> GetAllTaskGroups()
        {
            yield return new TaskGroup
            {
                Id = 1, 
                GroupName = "Important",
                Tasks = new List<Task> { new Task { Id = 1, Content = "random content" } }
            };
            yield return new TaskGroup
            {
                Id = 2, 
                GroupName = "New",
                Tasks = new List<Task> { new Task { Id = 2, Content = "todo something" } }
            };
        }

        public int CreateTaskGroup(CreateTaskGroupRequest request)
        {
            var taskGroup = new TaskGroup
            {
                Id = 1, 
                GroupName = "Important",
                Tasks = new List<Task> { new Task { Id = 1, Content = "random content" } }
            };

            return taskGroup.Id;
        }

        public void DeleteTaskGroupById(int groupId)
        {
            
        }

        public void UpdateTaskGroupName(int groupId, string newName)
        {
            
        }
    }
}