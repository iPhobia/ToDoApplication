using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Core.Services
{
    public class TodoTodoTaskGroupsService : ITodoTaskGroupsService
    {
        public Task<IEnumerable<TodoTaskGroup>> GetAllTodoTaskGroups()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTodoTaskGroupById(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateTodoTaskGroupName(int groupId, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}