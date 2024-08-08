using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PolyDo.Controllers;
using PolyDo.Application.DTOs;
using PolyDo.Application.Services;
using PolyDo.Domain.Entities;
using PolyDo.Model;
using System.Threading.Tasks;
using Xunit;

namespace PolyDo.UniTests {
    public class UserControllerTests {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;
        private readonly JwtSettings _jwtSettings;

        public UserControllerTests() {
            _userServiceMock = new Mock<IUserService>();
            _jwtSettings = new JwtSettings
            {
                SecretKey = "your_secret_key_here",
                Issuer = "your_issuer",
                Audience = "your_audience",
                ExpiryInMinutes = 60
            };
            var jwtSettings = Options.Create(_jwtSettings);
            _userController = new UserController(jwtSettings, _userServiceMock.Object);
        }

        [Fact]
        public async Task Register_ShouldReturnOk_WithToken() {
            var userDto = new UserDto { UserName = "testuser", Password = "password123" };
            _userServiceMock.Setup(s => s.GetAsync(userDto.UserName)).ReturnsAsync((UserDto)null);
            _userServiceMock.Setup(s => s.AddAsync(userDto)).Returns(Task.CompletedTask);

            var result = await _userController.Register(userDto) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task Login_ShouldReturnOk_WithToken() {
            var userDto = new UserDto { UserName = "testuser", Password = "password123" };
            _userServiceMock.Setup(s => s.GetAsync(userDto.UserName)).ReturnsAsync(userDto);

            var result = await _userController.Login(userDto) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
        }
    }
}
