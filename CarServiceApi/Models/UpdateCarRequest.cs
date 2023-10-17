namespace CarServiceApi.Models
{
    public class UpdateCarRequest
    {
        public Guid CarId { get; set; }
        public string Brand { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
    }
}
