using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.RentedCarDtos;
using RentCar.Application.Services.RentedCar;

namespace RentCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedCarsController : ControllerBase
    {
        private readonly IRentedCarService _rentedCarService;
        public RentedCarsController(IRentedCarService rentedCarService)
        {
            _rentedCarService = rentedCarService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRentedCars()
        {
            var result = await _rentedCarService.GetAllRentedCarsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentedCarById(int id)
        {
            var result = await _rentedCarService.GetRentedCarByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRentedCar([FromBody] CreateRentedCarDto rentedCarDto)
        {
            await _rentedCarService.CreateRentedCarAsync(rentedCarDto);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRentedCar([FromBody] UpdateRentedCarDto rentedCarDto)
        {
            await _rentedCarService.UpdateRentedCarAsync(rentedCarDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentedCar(int id)
        {
            await _rentedCarService.DeleteRentedCarAsync(id);
            return NoContent();
        }
    }
}
