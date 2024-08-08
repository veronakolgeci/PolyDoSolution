using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;

namespace PolyDo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubTasksController : ControllerBase {
        private readonly ISubTaskService _subTaskService;
        private readonly IParentTaskService _parentTaskService;

        public SubTasksController(ISubTaskService subTaskService, IParentTaskService parentTaskService) {
            _subTaskService = subTaskService;
            _parentTaskService = parentTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubTasks() {
            var subTasks = await _subTaskService.GetAllSubTasksAsync();
            return Ok(subTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubTask(int id) {
            var subTask = await _subTaskService.GetSubTaskByIdAsync(id);
            if (subTask == null) {
                return NotFound();
            }
            return Ok(subTask);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubTask([FromBody] SubTaskDto subTaskDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var task = await _parentTaskService.GetTaskByIdAsync(subTaskDto.TaskId);
            if (task == null) {
                return NotFound("Task not found");
            }

            await _subTaskService.AddSubTaskAsync(subTaskDto);
            return CreatedAtAction(nameof(GetSubTask), new { id = subTaskDto.Id }, subTaskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubTask(int id, [FromBody] SubTaskDto subTaskDto) {
            if (id != subTaskDto.Id || !ModelState.IsValid) {
                return BadRequest();
            }

            var existingSubTask = await _subTaskService.GetSubTaskByIdAsync(id);
            if (existingSubTask == null) {
                return NotFound();
            }

            existingSubTask.Title = subTaskDto.Title;
            existingSubTask.Description = subTaskDto.Description;
            existingSubTask.TaskId = subTaskDto.TaskId;

            await _subTaskService.UpdateSubTaskAsync(existingSubTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTask(int id) {
            var subTask = await _subTaskService.GetSubTaskByIdAsync(id);
            if (subTask == null) {
                return NotFound();
            }

            await _subTaskService.DeleteSubTaskAsync(id);
            return NoContent();
        }
    }
}
