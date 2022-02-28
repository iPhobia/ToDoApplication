using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;

namespace ToDoApp.Core.Interfaces
{
    public interface ITodoTasksQueryService
    {
        Task<IEnumerable<TodoTask>> GetAllTodoTasks();
        Task UpdateTodoTaskContent(int id, string newContent);
        Task<int> CreateTodoTask(CreateTodoTaskRequest request);
    }
}