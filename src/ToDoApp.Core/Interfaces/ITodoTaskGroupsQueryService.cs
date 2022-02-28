using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;

namespace ToDoApp.Core.Interfaces
{
    public interface ITodoTaskGroupsQueryService
    {
        Task<IEnumerable<TodoTaskGroup>> GetAllTodoTaskGroups();
        Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request);
        Task DeleteTodoTaskGroupById(int groupId);
        Task UpdateTodoTaskGroupName(int groupId, string newName);
        Task<IEnumerable<TodoTask>> GetTasksByGroupId(int groupId);
    }
}