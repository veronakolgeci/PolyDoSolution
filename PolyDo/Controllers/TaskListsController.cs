using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Repositories;
using System.Collections.Generic;

namespace PolyDo.Controllers {
    [Route("polydo/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskListsController : Controller {
        private readonly ITaskListService _taskListService;

        public TaskListsController(ITaskListService taskListService) {
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLists() {
            var lists = await _taskListService.GetAllListsAsync();
            return Ok(lists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(int id) {
            var list = await _taskListService.GetListByIdAsync(id);
            if (list == null) {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] TaskListDto listDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _taskListService.AddListAsync(listDto);
            return CreatedAtAction(nameof(GetList), new { id = listDto.Id }, listDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, [FromBody] TaskListDto listDto) {
            if (id != listDto.Id || !ModelState.IsValid) {
                return BadRequest();
            }

            await _taskListService.UpdateListAsync(listDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id) {
            await _taskListService.DeleteListAsync(id);
            return NoContent();
        }
    }
}
