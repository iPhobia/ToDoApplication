using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Core.Services
{
    public class TodoTaskGroupsService : ITodoTaskGroupsService
    {
        private readonly ITodoTaskGroupsQueryService _queryService;

        public TodoTaskGroupsService(ITodoTaskGroupsQueryService queryService)
        {
            _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
        }

        public async Task<IEnumerable<TodoTaskGroupDto>> GetAllTodoTaskGroups()
        {
            var todoTaskGroups =  await _queryService.GetAllTodoTaskGroups();

            return todoTaskGroups.Select(g => new TodoTaskGroupDto
            {
                Id = g.Id,
                GroupName = g.GroupName
            });
        }

        public async Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request)
        {
            var createdGroupId = await _queryService.CreateTodoTaskGroup(request);

            return createdGroupId;
        }

        public async Task DeleteTodoTaskGroupById(int groupId)
        {
            await _queryService.DeleteTodoTaskGroupById(groupId);
        }

        public async Task UpdateTodoTaskGroupName(int groupId, string newName)
        {
            await _queryService.UpdateTodoTaskGroupName(groupId, newName);
        }

        public async Task<IEnumerable<TodoTaskDto>> GetTasksByGroupId(int groupId)
        { 
            var tasks = await _queryService.GetTasksByGroupId(groupId);
            
            return tasks.Select(t => new TodoTaskDto
            {
                Id = t.Id,
                Content = t.Content
            });
        }
    }
}