using CarServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApi.Data
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
