using RentCar.Application.Dtos.UserDtos;

namespace RentCar.Application.Services.User
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
        Task<GetUserByIdDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UpdateUserDto user);

        Task DeleteUserAsync(int id);
    }
}
