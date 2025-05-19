using RentCar.Application.Dtos.CarDtos;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;

namespace RentCar.Application.Services.Car
{
    public class CarServices:ICarServices
    {
        private readonly ICarRepository _carRepository;
        public CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<ResultCarDto>> GetAllCarsAsync()
        {
           var entity =await  _carRepository.GetAllCarsAsync();
           var result = entity.Select(x => new ResultCarDto
           {
               Id = x.Id,
               ImageUrl = x.ImageUrl,
               Brand = x.Brand, 
               Model = x.Model,
               Year = x.Year,
               Mileage = x.Mileage,
               Type = x.Type,
               Fuel = x.Fuel,
               Color = x.Color,
               PricePerDay = x.PricePerDay,
               IsAvailable = x.IsAvailable

           }).ToList();
           return result;
        }

        public async Task<GetCarById> GetCarByIdAsync(int id)
        {
            var entity =await _carRepository.GetCarByIdAsync(id);
            var result = new GetCarById
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Brand = entity.Brand,
                Model = entity.Model,
                Year = entity.Year,
                Mileage = entity.Mileage,
                Type = entity.Type,
                Fuel = entity.Fuel,
                Color = entity.Color,
                PricePerDay = entity.PricePerDay,
                IsAvailable = entity.IsAvailable
            };
            return result;
        }

        public async Task AddCarAsync(CreateCarDtos car)
        {
            var value = new Domain.Entities.Car
            {
                ImageUrl = car.ImageUrl,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Type = car.Type,
                Fuel = car.Fuel,
                Color = car.Color,
                PricePerDay = car.PricePerDay,
                IsAvailable = true
            };
            await _carRepository.AddCarAsync(value);

        }

        public async Task UpdateCarAsync(UpdateCarDto car)
        {
            var entity = await _carRepository.GetCarByIdAsync(car.Id);
            entity.ImageUrl = car.ImageUrl;
            entity.Brand = car.Brand;
            entity.Model = car.Model;
            entity.Year = car.Year;
            entity.Mileage = car.Mileage;
            entity.Type = car.Type;
            entity.Fuel = car.Fuel;
            entity.Color = car.Color;
            entity.PricePerDay = car.PricePerDay;
            entity.IsAvailable = car.IsAvailable;
            await _carRepository.UpdateCar(entity);

        }

        public async Task DeleteCarAsync(int id)
        {
            var entity =await _carRepository.GetCarByIdAsync(id);
            if (entity != null)
            {
                await _carRepository.DeleteCar(id);
            }
            else
            {
                throw new Exception("Car not found");
            }
        }
    }
}
