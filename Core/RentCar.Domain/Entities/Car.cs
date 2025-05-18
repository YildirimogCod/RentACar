namespace RentCar.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Type { get; set; }    
        public string Fuel { get; set; }
        public string Color { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
