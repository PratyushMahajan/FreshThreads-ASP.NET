using FreshThreads.Repositories.Interface;
using JWTImplementation.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreshThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _authService;

        public UsersController(IUserRepository authService)
        {
            _authService = authService;
        }

        [HttpGet("get")]
        public List<Users> GetAllUsers()
        {
            return _authService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Users GetUserById(long id)
        {
            return _authService.GetUserById(id);
        }

        [HttpPost("create")]
        public Users CreateUser([FromBody] Users user)
        {
            return _authService.CreateUser(user);
        }

        // PUT: api/users/{id}

        [HttpPut("{id}")]
        public Users UpdateUser(int id,[FromBody] Users user)
        {
            return _authService.UpdateUser(user);
        }
        // Delete: api/users/{id}
        [HttpDelete("{id}")]
        public bool DeleteUser(long id)
        {
            return _authService.DeleteUser(id);
        }





    }
}
