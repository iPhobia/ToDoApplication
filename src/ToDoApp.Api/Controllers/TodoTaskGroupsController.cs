using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.DTO;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Exceptions;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskGroupsController : ControllerBase
    {
        private readonly ITodoTaskGroupsService _todoTaskGroupsService;

        public TodoTaskGroupsController(ITodoTaskGroupsService todoTaskGroupsService)
        {
            _todoTaskGroupsService = todoTaskGroupsService ?? throw new ArgumentNullException(nameof(todoTaskGroupsService));;
        }
        
        // GET: api/todoTaskGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTaskGroupDto>>> Get()
        {
            try
            {
                var response = await _todoTaskGroupsService.GetAllTodoTaskGroups();
                
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST: api/groups
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateTodoTaskGroupRequest request)
        {
            try
            {
                var response = await _todoTaskGroupsService.CreateTodoTaskGroup(request);
                
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT: api/todoTaskGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string newTaskGroupName)
        {
            try
            {
                if (id <= 0)
                {
                    ModelState.AddModelError(nameof(id), "id cannot be 0 or less than 0");
                }
                
                if (string.IsNullOrEmpty(newTaskGroupName))
                {
                    ModelState.AddModelError(nameof(newTaskGroupName), "invalid value for group name");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                await _todoTaskGroupsService.UpdateTodoTaskGroupName(id, newTaskGroupName);
                
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE: api/todoTaskGroups/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Problem("invalid value for id", statusCode: StatusCodes.Status400BadRequest);
                }

                await _todoTaskGroupsService.DeleteTodoTaskGroupById(id);

                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET: api/todoTaskGroups/5/tasks
        [HttpGet("{id:int}/tasks")]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetTasksByGroupId(int id)
        {
            try
            {
                var response = await _todoTaskGroupsService.GetTasksByGroupId(id);

                return Ok(response);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
