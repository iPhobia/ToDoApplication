using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TodoTasksService : ITodoTasksService
    {
        public Task<IEnumerable<TodoTaskDto>> GetAllTodoTasks()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateTodoTaskContent(string newContent)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateTodoTask(CreateTodoTaskRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}