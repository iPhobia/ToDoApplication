using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TodoTaskGroupsServiceStub : ITodoTaskGroupsService
    {
        public async Task<IEnumerable<TodoTaskGroupDto>> GetAllTodoTaskGroups()
        {
            return new List<TodoTaskGroupDto>()
            {
                new TodoTaskGroupDto
                {
                    Id = 1,
                    GroupName = "Important"
                },
                new TodoTaskGroupDto
                {
                    Id = 2,
                    GroupName = "New"
                }
            };
        }

        public Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request)
        {
            var taskGroup = new TodoTaskGroupDto
            {
                Id = 1, 
                GroupName = "Important"
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

        public async Task<IEnumerable<TodoTaskDto>> GetTasksByGroupId(int groupId)
        {
            return new List<TodoTaskDto>
            {
                new TodoTaskDto { Id = groupId, Content = "todo" }
            };
        }
    }
}