using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Core.Interfaces
{
    public interface ITodoTaskGroupsService
    {
        Task<IEnumerable<TodoTaskGroupDto>> GetAllTodoTaskGroups();
        Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request);
        Task DeleteTodoTaskGroupById(int groupId);
        Task UpdateTodoTaskGroupName(int groupId, string newName);
        Task<IEnumerable<TodoTaskDto>> GetTasksByGroupId(int groupId);
    }
}