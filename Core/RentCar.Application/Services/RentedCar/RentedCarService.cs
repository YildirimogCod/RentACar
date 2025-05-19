using RentCar.Application.Dtos.RentedCarDtos;
using RentCar.Application.Dtos.UserDtos;
using RentCar.Application.Interfaces.Repositories;

namespace RentCar.Application.Services.RentedCar
{
    public class RentedCarService:IRentedCarService
    {
        private readonly IRentedCarRepository _rentedCarRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;
        public RentedCarService(IRentedCarRepository rentedCarRepository, ICarRepository carRepository, IUserRepository userRepository)
        {
            _rentedCarRepository = rentedCarRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }
        public async Task<List<ResultRentedCarDto>> GetAllRentedCarsAsync()
        {
            var value =await _rentedCarRepository.GetRentedCarsAsync();
            var result = new List<ResultRentedCarDto>();
            foreach (var item in value)
            {
                var car = await _carRepository.GetCarByIdAsync(item.CarId);
                var user = await _userRepository.GetUserByIdAsync(item.UserId);
                var newRentedCar = new ResultRentedCarDto{
                Id = item.Id,
                CarId = item.CarId,
                UserId = item.UserId,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                TotalPrice = item.TotalPrice,
                DamagePrice = item.DamagePrice,
                IsReturned = item.IsReturned
                };
                newRentedCar.User = new InfoForUser
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                };
                newRentedCar.Car = car;
                //item.User = user;
                result.Add(newRentedCar);
            }
            return result;
        }

        public async Task<GetRentedCarByIdDto> GetRentedCarByIdAsync(int id)
        {
            var value =await _rentedCarRepository.GetRentedCarByIdAsync(id);
            var car = await _carRepository.GetCarByIdAsync(value.CarId);
            var user = await _userRepository.GetUserByIdAsync(value.UserId);
            if (value == null)
            {
                throw new Exception("Rented car not found");
            }
            var result = new GetRentedCarByIdDto
            {
                Id = value.Id,
                CarId = value.CarId,
                UserId = value.UserId,
                StartDate = value.StartDate,
                EndDate = value.EndDate,
                TotalPrice = value.TotalPrice,
                DamagePrice = value.DamagePrice,
                IsReturned = value.IsReturned
            };
            result.User = new InfoForUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            };
            result.Car = car;
            return result;
        }

        public async Task CreateRentedCarAsync(CreateRentedCarDto rentedCarDto)
        {
            var entity = new Domain.Entities.RentedCar
            {
                CarId = rentedCarDto.CarId,
                UserId = rentedCarDto.UserId,
                StartDate = rentedCarDto.StartDate,
                EndDate = rentedCarDto.EndDate,
                TotalPrice = rentedCarDto.TotalPrice,
                DamagePrice = rentedCarDto.DamagePrice,
                IsReturned = rentedCarDto.IsReturned
            };
            await _rentedCarRepository.AddRentedCarAsync(entity);
        }

        public async Task UpdateRentedCarAsync(UpdateRentedCarDto rentedCarDto)
        {
            var value =await _rentedCarRepository.GetRentedCarByIdAsync(rentedCarDto.Id);
            value.Id = rentedCarDto.Id;
            value.CarId = rentedCarDto.CarId;
            value.UserId = rentedCarDto.UserId;
            value.StartDate = rentedCarDto.StartDate;
            value.EndDate = rentedCarDto.EndDate;
            value.TotalPrice = rentedCarDto.TotalPrice;
            value.DamagePrice = rentedCarDto.DamagePrice;
            value.IsReturned = rentedCarDto.IsReturned;
 
           await  _rentedCarRepository.UpdateRentedCarAsync(value);
        }

        public async Task DeleteRentedCarAsync(int id)
        {
            var value =await _rentedCarRepository.GetRentedCarByIdAsync(id);
            await  _rentedCarRepository.DeleteRentedCarAsync(value);
        }
    }
}
