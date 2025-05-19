using Microsoft.EntityFrameworkCore;
using RentCar.Application.Dtos.RentedCarDtos;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.RentedCarRepositories
{
    public class RentedCarRepository:IRentedCarRepository
    {
        private readonly RentCarDbContext _context;
        public RentedCarRepository(RentCarDbContext context)
        {
            _context = context;
        }
        public async Task<List<RentedCar>> GetRentedCarsAsync()
        {
            var value = await _context.RentedCars.Include(x => x.Car).ToListAsync();
            return value;
        }

        public async Task<RentedCar> GetRentedCarByIdAsync(int id)
        {
            var value =await _context.RentedCars.FirstOrDefaultAsync(r => r.Id == id);
            return value;
        }

        public  async Task AddRentedCarAsync(RentedCar rentedCar)
        {
            await _context.RentedCars.AddAsync(rentedCar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRentedCarAsync(RentedCar rentedCar)
        {
            _context.RentedCars.Update(rentedCar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentedCarAsync(RentedCar rentedCar)
        {
            _context.RentedCars.Remove(rentedCar);
            await _context.SaveChangesAsync();
        }
    }
}
