namespace CarServiceApi.Models
{
    public class AddCarRequest
    {
        public string Brand { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
    }
}
