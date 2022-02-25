using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;

namespace ToDoApp.Core.Interfaces
{
    public interface ITodoTasksService
    {
        Task<IEnumerable<TodoTaskDto>> GetAllTodoTasks();
        Task UpdateTodoTaskContent(string newContent);
        Task<int> CreateTodoTask(CreateTodoTaskRequest request);
    }
}