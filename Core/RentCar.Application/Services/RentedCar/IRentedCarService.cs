using RentCar.Application.Dtos.RentedCarDtos;

namespace RentCar.Application.Services.RentedCar
{
    public interface IRentedCarService
    {
        Task<List<ResultRentedCarDto>> GetAllRentedCarsAsync();
        Task<GetRentedCarByIdDto> GetRentedCarByIdAsync(int id);
        Task CreateRentedCarAsync(CreateRentedCarDto rentedCarDto);
        Task UpdateRentedCarAsync (UpdateRentedCarDto rentedCarDto);
        Task DeleteRentedCarAsync(int id);

    }
}
