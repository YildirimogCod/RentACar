using RentCar.Application.Dtos.UserDtos;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;

namespace RentCar.Application.Services.User
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            var entity =await _userRepository.GetAllUsersAsync();
            var result = entity.Select(user => new ResultUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                RentedCars = new List<Domain.Entities.RentedCar>()
            }).ToList();
            return result;

        }
        public async Task<GetUserByIdDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user is null) return null;
            return new GetUserByIdDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                RentedCars = user.RentedCars,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
        public async Task CreateUserAsync(CreateUserDto user)
        {
            var value = new Domain.Entities.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Role = user.Role,
            };
            await _userRepository.CreateUserAsync(value);

        }
        public async Task UpdateUserAsync(UpdateUserDto user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.Id);
            if (existingUser == null) return;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Role = user.Role;
            await _userRepository.UpdateUserAsync(existingUser);
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return;
            await _userRepository.DeleteUserAsync(user);
        }
    }
}
