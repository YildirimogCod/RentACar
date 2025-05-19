using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(int id);
    }
}
