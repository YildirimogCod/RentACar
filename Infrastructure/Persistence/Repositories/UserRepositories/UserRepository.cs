using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.UserRepositories
{
    public class UserRepository:IUserRepository
    {
        private readonly RentCarDbContext _context;
        public UserRepository(RentCarDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsersAsync() =>await _context.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public Task DeleteUserAsync(User user)
        {
           _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }
    }
}
