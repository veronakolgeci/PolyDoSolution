using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;

namespace PolyDo.Controllers {
    [ApiController]
    [Route("tasks")]
    [Authorize]
    public class ParentTasksController : ControllerBase {
        private readonly IParentTaskService _parentTaskService;
        private readonly ISubTaskService _subTaskService;

        public ParentTasksController(IParentTaskService parentTaskService, ISubTaskService subTaskService) {
            _parentTaskService = parentTaskService;
            _subTaskService = subTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks() {
            var tasks = await _parentTaskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id) {
            var task = await _parentTaskService.GetTaskByIdAsync(id);
            if (task == null) {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] ParentTaskDto taskDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _parentTaskService.AddTaskAsync(taskDto);
            return CreatedAtAction(nameof(GetTask), new { id = taskDto.Id }, taskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] ParentTaskDto taskDto) {
            if (id != taskDto.Id || !ModelState.IsValid) {
                return BadRequest();
            }

            await _parentTaskService.UpdateTaskAsync(taskDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id) {
            await _parentTaskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpPost("{taskId}/subtasks")]
        public async Task<IActionResult> AddSubTask(int taskId, [FromBody] SubTaskDto subTaskDto) {
            var task = await _parentTaskService.GetTaskByIdAsync(taskId);
            if (task == null) {
                return NotFound();
            }

            await _subTaskService.AddSubTaskAsync(subTaskDto);
            return Ok(task);
        }
    }

}
