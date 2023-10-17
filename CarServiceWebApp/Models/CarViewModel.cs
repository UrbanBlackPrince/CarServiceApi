using System.ComponentModel.DataAnnotations;

namespace CarServiceWebApp.Models
{
    public class CarViewModel
    {
       
        public Guid Id { get; set; }


       [Required]
        public string Brand { get; set; } = null!;


        [Required]
        public string Color { get; set; } = null!;


        [Required]
        public string RegistrationNumber { get; set; } = null!;
    }
}
