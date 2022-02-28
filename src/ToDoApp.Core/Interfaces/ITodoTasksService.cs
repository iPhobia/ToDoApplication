using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;

namespace ToDoApp.Core.Interfaces
{
    public interface ITodoTasksService
    {
        Task<IEnumerable<TodoTaskDto>> GetAllTodoTasks();
        Task UpdateTodoTaskContent(int id, string newContent);
        Task<int> CreateTodoTask(CreateTodoTaskRequest request);
    }
}