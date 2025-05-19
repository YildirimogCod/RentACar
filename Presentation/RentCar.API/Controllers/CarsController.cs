using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.CarDtos;
using RentCar.Application.Services.Car;

namespace RentCar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarServices _carServices;
        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await _carServices.GetAllCarsAsync();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _carServices.GetCarByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarDtos car)
        {
            await _carServices.AddCarAsync(car);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDto car)
        {
            await _carServices.UpdateCarAsync(car);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carServices.DeleteCarAsync(id);
            return Ok();
        }
    }
}
