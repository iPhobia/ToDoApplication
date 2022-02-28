using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Exceptions;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Infrastructure.Data.QueryServices
{
    public class TodoTaskGroupsQueryService : ITodoTaskGroupsQueryService
    {
        private readonly TodoDbContext _dbContext;

        public TodoTaskGroupsQueryService(TodoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<IEnumerable<TodoTaskGroup>> GetAllTodoTaskGroups()
        {
            var taskGroups = await _dbContext.TodoTaskGroups
                .AsNoTracking()
                .ToListAsync();

            return taskGroups;
        }

        public async Task<int> CreateTodoTaskGroup(CreateTodoTaskGroupRequest request)
        {
            var taskGroup = new TodoTaskGroup
            {
                GroupName = request.GroupName
            };

            await _dbContext.AddAsync(taskGroup);
            await _dbContext.SaveChangesAsync();

            return taskGroup.Id;
        }

        public async Task DeleteTodoTaskGroupById(int groupId)
        {
            var taskGroup = await _dbContext.TodoTaskGroups.FirstOrDefaultAsync(t => t.Id == groupId);

            if (taskGroup == null)
                throw new EntityNotFoundException($"task group with id: {groupId} is not found");
                    
            _dbContext.TodoTaskGroups.Remove(taskGroup);
        }

        public async Task UpdateTodoTaskGroupName(int groupId, string newName)
        {
            var taskGroup = await _dbContext.TodoTaskGroups.FirstOrDefaultAsync(t => t.Id == groupId);

            if (taskGroup == null)
                throw new EntityNotFoundException($"task group with id: {groupId} is not found");

            taskGroup.GroupName = newName;
                    
            _dbContext.TodoTaskGroups.Update(taskGroup);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByGroupId(int groupId)
        {
            var taskGroup = await _dbContext.TodoTaskGroups.Include(g => g.Tasks)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == groupId);

            if (taskGroup == null)
                throw new EntityNotFoundException($"task group with id: {groupId} is not found");

            return taskGroup.Tasks;
        }
    }
}