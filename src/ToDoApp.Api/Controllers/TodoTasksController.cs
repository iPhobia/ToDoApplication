using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTasksService _todoTasksService;

        public TodoTasksController(ITodoTasksService todoTasksService)
        {
            _todoTasksService = todoTasksService ?? throw new ArgumentNullException(nameof(todoTasksService));
        }

        // GET: api/TodoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> Get()
        {
            try
            {
                var todoTasks = await _todoTasksService.GetAllTodoTasks();
                
                return Ok(todoTasks);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST: api/TodoTasks
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateTodoTaskRequest request)
        {
            try
            {
                var response = await _todoTasksService.CreateTodoTask(request);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT: api/TodoTasks/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] string taskContent)
        {
            try
            {
                if (string.IsNullOrEmpty(taskContent))
                {
                    return Problem("task content cannot be null or empty", statusCode: StatusCodes.Status400BadRequest);
                }
                
                await _todoTasksService.UpdateTodoTaskContent(taskContent);
                
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
