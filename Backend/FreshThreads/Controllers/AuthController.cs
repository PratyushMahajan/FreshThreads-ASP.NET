using FreshThreads.DTO;
using JWTImplementation.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // POST api/<AuthController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest value)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var result = _authService.Login(value);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(new { Token = result });
        }


        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

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
