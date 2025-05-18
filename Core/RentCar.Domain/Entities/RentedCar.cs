namespace RentCar.Domain.Entities
{
    public class RentedCar
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
        public User User { get; set; }

    }
}
