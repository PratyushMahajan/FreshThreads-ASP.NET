using System.Linq;
using FreshThreads.DTO;
using JWTImplementation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<AuthController>/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest value)
        {
            var loginResult = _authService.Login(value);

            if (loginResult == null || string.IsNullOrEmpty(loginResult.Token))
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            // Returning role along with the JWT token
            return Ok(new
            {
                Token = loginResult.Token,
                Role = loginResult.Role  // Added role in response
            });
        }

        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            var result = _authService.AddUser(user);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Failed to create user" });
            }

            return CreatedAtAction(nameof(AddUser), new { id = result.UsersId }, result);
        }
    }
}
