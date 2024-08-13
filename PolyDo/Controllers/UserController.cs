using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PolyDo.Application.DTOs;
using PolyDo.Application.Services;
using PolyDo.Domain.Entities;
using PolyDo.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PolyDo.Controllers {
    [ApiController]
    [Route("polydo/user")]
    public class UserController : Controller {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;

        public UserController(IOptions<JwtSettings> jwtSettings, IUserService userService) {
            _jwtSettings = jwtSettings.Value;
            _userService = userService;
        }

        [HttpGet("login")]
        public IActionResult Login() {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register() {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto) {
            var existingUser = await _userService.GetAsync(userDto.UserName);
            if (existingUser != null) {
                return BadRequest(new { Message = "Username already taken" });
            }

            await _userService.AddAsync(userDto);

            var token = GenerateJwtToken(userDto.UserName);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto) {
            var user = await _userService.GetAsync(userDto.UserName);
            if (user == null || user.Password != userDto.Password) {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var token = GenerateJwtToken(user.UserName);
            return RedirectToAction("Index", "Home");
        }

        private string GenerateJwtToken(string username) {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
