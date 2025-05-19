using RentCar.Application.Dtos.UserDtos;
using RentCar.Domain.Entities;

namespace RentCar.Application.Dtos.RentedCarDtos
{
    public class ResultRentedCarDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DamagePrice { get; set; }
        public bool IsReturned { get; set; }
        public Car Car { get; set; }
        public InfoForUser User { get; set; }
    }
}
