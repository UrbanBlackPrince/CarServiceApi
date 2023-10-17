using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceApi.Models
{
    public class Car
    {
        [Comment("Primary key")]
        [Key]
        public Guid Id { get; set; }


        [Comment("Car Brand")]
        [Required]
        public string Brand { get; set; } = null!;


        [Comment("Car Color")]
        [Required]
        public string Color { get; set; } = null!;


        [Comment("Car Registration Number")]
        public string RegistrationNumber { get; set; } = null!;

    }
}

