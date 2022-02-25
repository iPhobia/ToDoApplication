using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.DTO.Requests;
using ToDoApp.Core.Entites;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ITaskGroupsServiceInterface _taskGroupsService;

        public GroupsController(ITaskGroupsServiceInterface taskGroupsService)
        {
            _taskGroupsService = taskGroupsService;
        }
        
        // GET: api/groups
        [HttpGet]
        public ActionResult<IEnumerable<TaskGroup>> Get()
        {
            try
            {
                return Ok(_taskGroupsService.GetAllTaskGroups());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST: api/groups
        [HttpPost]
        public ActionResult<int> Post([FromBody] CreateTaskGroupRequest request)
        {
            try
            {
                return Ok(_taskGroupsService.CreateTaskGroup(request));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT: api/groups/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] string newTaskGroupName)
        {
            try
            {
                _taskGroupsService.UpdateTaskGroupName(id.Value, newTaskGroupName);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE: api/groups/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            try
            {
                _taskGroupsService.DeleteTaskGroupById(id.Value);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
