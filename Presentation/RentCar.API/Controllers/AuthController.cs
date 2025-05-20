using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.AuthDtos;
using RentCar.Application.Services.Auth;
using RentCar.Persistence.Services.AuthServices;

namespace RentCar.API.Controllers
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
        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            if (request.Email == "admin@gmail.com" && request.Password == "123")
            {
                var token = _authService.GenerateToken();
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
