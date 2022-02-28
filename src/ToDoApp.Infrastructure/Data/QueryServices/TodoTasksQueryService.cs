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
    public class TodoTasksQueryService : ITodoTasksQueryService
    {
        private readonly TodoDbContext _dbContext;

        public TodoTasksQueryService(TodoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task<IEnumerable<TodoTask>> GetAllTodoTasks()
        {
            // var tasksGroups = await _dbContext.TodoTaskGroups.AsNoTracking()
            //     .ToListAsync();
            //
            // return tasksGroups.SelectMany(g => g.Tasks);
            
            return await _dbContext.TodoTasks.AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateTodoTaskContent(int id, string newContent)
        {
            var task = await _dbContext.TodoTasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                throw new EntityNotFoundException($"task with id: {id} is not found");

            task.Content = newContent;
                    
            _dbContext.TodoTasks.Update(task);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateTodoTask(CreateTodoTaskRequest request)
        {
            TodoTaskGroup taskGroup;

            if (request.GroupId.HasValue)
            {
                taskGroup = await _dbContext.TodoTaskGroups.FirstOrDefaultAsync(g => g.Id == request.GroupId)
                            ?? throw new EntityNotFoundException($"task group with id: {request.GroupId} is not found");
                
            }
            else
            {
                taskGroup = await _dbContext.TodoTaskGroups.FirstAsync(g => g.GroupName.Equals("My day"));
            }
            
            var task = new TodoTask
            {
                Content = request.Content,
            };

            taskGroup.Tasks.Add(task);
            
            await _dbContext.TodoTasks.AddAsync(task);

            await _dbContext.SaveChangesAsync();

            return task.Id;
        }
    }
}