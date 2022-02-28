using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
    public class TodoTasksService : ITodoTasksService
    {
        private readonly ITodoTasksQueryService _todoTasksQueryService;

        public TodoTasksService(ITodoTasksQueryService todoTasksQueryService)
        {
            _todoTasksQueryService =
                todoTasksQueryService ?? throw new ArgumentNullException(nameof(todoTasksQueryService));
        }

        public async Task<IEnumerable<TodoTaskDto>> GetAllTodoTasks()
        {
           var tasks =  await _todoTasksQueryService.GetAllTodoTasks();

           return tasks.Select(t => new TodoTaskDto
           {
               Id = t.Id,
               Content = t.Content
           });
        }

        public async Task UpdateTodoTaskContent(int id, string newContent)
        {
            await _todoTasksQueryService.UpdateTodoTaskContent(id, newContent);
        }

        public async Task<int> CreateTodoTask(CreateTodoTaskRequest request)
        {
           return await _todoTasksQueryService.CreateTodoTask(request);
        }
    }
}