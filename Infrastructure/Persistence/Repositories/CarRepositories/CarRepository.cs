using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CarRepositories
{
    public class CarRepository:ICarRepository
    {
        private readonly RentCarDbContext _context;
        public CarRepository(RentCarDbContext context)
        {
            _context = context;
        }
        public async Task<List<Car>> GetAllCarsAsync() =>await _context.Cars.ToListAsync();

        public async Task<Car> GetCarByIdAsync(int id) => await _context.Cars.FindAsync(id);

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public Task UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            return _context.SaveChangesAsync();
        }

        public Task DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }
    }
}
