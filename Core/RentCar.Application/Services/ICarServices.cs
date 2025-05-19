
using RentCar.Application.Dtos.CarDtos;

namespace RentCar.Application.Services
{
    public interface ICarServices
    {
        Task<List<ResultCarDto>> GetAllCarsAsync();
        Task<GetCarById> GetCarByIdAsync(int id);
        Task AddCarAsync(CreateCarDtos car);
        Task UpdateCarAsync(UpdateCarDto car);

        Task DeleteCarAsync(int id);
    }
}
