using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TodoTasksServiceStub : ITodoTasksService
    {

        public async Task<IEnumerable<TodoTaskDto>> GetAllTodoTasks()
        {
            var todoTask = new TodoTaskDto
            {
                Id = 1,
                Content = "content",
            };

            return new List<TodoTaskDto>()
            {
                todoTask
            };
        }

        public Task UpdateTodoTaskContent(string newContent)
        {
            return Task.CompletedTask;
        }

        public Task<int> CreateTodoTask(CreateTodoTaskRequest request)
        {
            return Task.FromResult<int>(1);
        }
    }
}