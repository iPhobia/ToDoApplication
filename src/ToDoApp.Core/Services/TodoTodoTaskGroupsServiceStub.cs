using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TodoTodoTaskGroupsServiceStub : ITodoTaskGroupsService
    {
        public async Task<IEnumerable<TodoTaskGroup>> GetAllTodoTaskGroups()
        {
            return new List<TodoTaskGroup>()
            {
                new TodoTaskGroup
                {
                    Id = 1,
                    GroupName = "Important",
                    TodoTasks = new List<ToDoTask> { new ToDoTask { Id = 1, Content = "random content" } }
                },
                new TodoTaskGroup
                {
                    Id = 2,
                    GroupName = "New",
                    TodoTasks = new List<ToDoTask> { new ToDoTask { Id = 2, Content = "todo something" } }
                }
            };
        }

        public Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request)
        {
            var taskGroup = new TodoTaskGroup
            {
                Id = 1, 
                GroupName = "Important",
                TodoTasks = new List<ToDoTask> { new ToDoTask { Id = 1, Content = "random content" } }
            };

            return Task.FromResult(taskGroup.Id);
        }

        public Task DeleteTodoTaskGroupById(int groupId)
        {
            return Task.CompletedTask;
        }

        public Task UpdateTodoTaskGroupName(int groupId, string newName)
        {
            return Task.CompletedTask;
        }
    }
}