using Moq;
using Microsoft.AspNetCore.Mvc;
using PolyDo.Controllers;
using PolyDo.Application.DTOs;
using PolyDo.Application.Services;
using PolyDo.Domain.Entities;
using System.Threading.Tasks;
using Xunit;
using PolyDo.Domain.Repositories;

namespace PolyDo.UniTests {
    public class SubTasksControllerTests {
        private readonly Mock<ISubTaskService> _subTaskServiceMock;
        private readonly Mock<IParentTaskService> _parentTaskServiceMock;
        private readonly SubTasksController _subTasksController;

        public SubTasksControllerTests() {
            _subTaskServiceMock = new Mock<ISubTaskService>();
            _parentTaskServiceMock = new Mock<IParentTaskService>();
            _subTasksController = new SubTasksController(_subTaskServiceMock.Object, _parentTaskServiceMock.Object);
        }

        [Fact]
        public async Task CreateSubTask_ShouldReturnCreated() {
            try {
                var subTaskDto = new SubTaskDto { Title = "New SubTask", Description = "Description", TaskId = 1 };
                _parentTaskServiceMock.Setup(s => s.GetTaskByIdAsync(subTaskDto.TaskId)).ReturnsAsync(new ParentTaskDto());
                _subTaskServiceMock.Setup(s => s.AddSubTaskAsync(subTaskDto)).Returns(Task.CompletedTask);

                var result = await _subTasksController.CreateSubTask(subTaskDto) as CreatedAtActionResult;

                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
            }
            catch (Exception ex) {

                Console.WriteLine($"Exception occurred on create subtask: {ex.Message}");
                throw;
            }
        }

        [Fact]
        public async Task DeleteSubTask_ShouldReturnNoContent() {
            try {
                var id = 1;
                _subTaskServiceMock.Setup(s => s.GetSubTaskByIdAsync(id)).ReturnsAsync(new SubTaskDto());
                _subTaskServiceMock.Setup(s => s.DeleteSubTaskAsync(id)).Returns(Task.CompletedTask);

                var result = await _subTasksController.DeleteSubTask(id) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
            catch (Exception ex) {

                Console.WriteLine($"Exception occurred on delete subtask: {ex.Message}");
                throw;
            }
        }
    }
}
