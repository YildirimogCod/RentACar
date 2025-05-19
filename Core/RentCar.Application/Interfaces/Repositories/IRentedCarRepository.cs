using RentCar.Application.Dtos.RentedCarDtos;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Repositories
{
    public interface IRentedCarRepository
    {
        Task<List<RentedCar>> GetRentedCarsAsync();
        Task<RentedCar> GetRentedCarByIdAsync(int id);
        Task AddRentedCarAsync(RentedCar rentedCar);
        Task UpdateRentedCarAsync(RentedCar rentedCar);
        Task DeleteRentedCarAsync(RentedCar rentedCar);
    }
}
