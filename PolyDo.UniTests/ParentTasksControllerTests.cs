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
    public class ParentTasksControllerTests {
        private readonly Mock<IParentTaskService> _parentTaskServiceMock;
        private readonly Mock<ISubTaskService> _subTaskServiceMock;
        private readonly ParentTasksController _parentTasksController;

        public ParentTasksControllerTests() {
            _parentTaskServiceMock = new Mock<IParentTaskService>();
            _subTaskServiceMock = new Mock<ISubTaskService>();
            _parentTasksController = new ParentTasksController(_parentTaskServiceMock.Object, _subTaskServiceMock.Object);
        }

        [Fact]
        public async Task CreateTask_ShouldReturnCreated() {
            var taskDto = new ParentTaskDto { Title = "New Task", Description = "Description" };
            _parentTaskServiceMock.Setup(s => s.AddTaskAsync(taskDto)).Returns(Task.CompletedTask);

            var result = await _parentTasksController.CreateTask(taskDto) as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task AddSubTask_ShouldReturnCreated() {
            var subTaskDto = new SubTaskDto { Title = "New SubTask", Description = "Description", TaskId = 1 };
            _parentTaskServiceMock.Setup(s => s.GetTaskByIdAsync(subTaskDto.TaskId)).ReturnsAsync(new ParentTaskDto());
            _subTaskServiceMock.Setup(s => s.AddSubTaskAsync(subTaskDto)).Returns(Task.CompletedTask);

            var result = await _parentTasksController.AddSubTask(1, subTaskDto) as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnNoContent() {
            var id = 1;
            _parentTaskServiceMock.Setup(s => s.DeleteTaskAsync(id)).Returns(Task.CompletedTask);

            var result = await _parentTasksController.DeleteTask(id) as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
    }
}