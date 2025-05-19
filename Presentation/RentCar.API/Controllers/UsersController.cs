using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.UserDtos;
using RentCar.Application.Services.User;

namespace RentCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.CreateUserAsync(user);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser is null) return NotFound();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
