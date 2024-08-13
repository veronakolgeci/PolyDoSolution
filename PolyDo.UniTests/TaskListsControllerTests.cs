using System;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;
using PolyDo.Controllers;
using PolyDo.Application.DTOs;
using PolyDo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using PolyDo.Domain.Repositories;

namespace PolyDo.UniTests {
    public class TaskListsControllerTests {
        private readonly Mock<ITaskListService> _taskListServiceMock;
        private readonly TaskListsController _taskListsController;

        public TaskListsControllerTests() {
            _taskListServiceMock = new Mock<ITaskListService>();
            _taskListsController = new TaskListsController(_taskListServiceMock.Object);
        }

        [Fact]
        public async Task CreateList_ShouldReturnCreated() {
            try {
                var listDto = new TaskListDto { Name = "New List", Description = "Description" };
                _taskListServiceMock.Setup(s => s.AddListAsync(listDto)).Returns(Task.CompletedTask);

                var result = await _taskListsController.CreateList(listDto) as CreatedAtActionResult;

                Assert.NotNull(result);
                Assert.Equal(201, result.StatusCode);
            }
            catch (Exception ex) {

                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        [Fact]
        public async Task DeleteList_ShouldReturnNoContent() {
            try {
                var id = 1;
                _taskListServiceMock.Setup(s => s.DeleteListAsync(id)).Returns(Task.CompletedTask);

                var result = await _taskListsController.DeleteList(id) as NoContentResult;

                Assert.NotNull(result);
                Assert.Equal(204, result.StatusCode);
            }
            catch (Exception ex) {

                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw;
            }
        }
    }
}
