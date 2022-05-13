namespace RentalCars.Domain.Commands
{
    public sealed class CreateCar
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public string ManufactureYear { get; set; }
        public string ModelYear { get; set; }
        public string Brand { get; set; }
        public string Plate { get; set; }
    }
}
