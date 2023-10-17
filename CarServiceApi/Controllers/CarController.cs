using CarServiceApi.Data;
using CarServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarController : Controller
    {
        #region Private fields and Constructors

        private CarServiceDbContext dbContext;

        public CarController(CarServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion Private fields and Constructors

        #region Public Action Results

        [HttpGet]
        public async Task<IActionResult> GetCarsAsync()
        {
            try
            {
                return Ok(await dbContext.Cars.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCarAsync(AddCarRequest request)
        {
            try
            {
                Car car = new Car()
                {
                    Id = Guid.NewGuid(),
                    Color = request.Color,
                    Brand = request.Brand,
                    RegistrationNumber = request.RegistrationNumber
                };
                await dbContext.Cars.AddAsync(car);
                await dbContext.SaveChangesAsync();

                return Ok(car);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] Guid id)
        {
            try
            {
                Car car = await dbContext.Cars.FindAsync(id);

                if (car == null)
                {
                    return NotFound(car);
                }

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCarAsync([FromRoute] Guid id, UpdateCarRequest request)
        {
            try
            {
                Car car = await dbContext.Cars.FindAsync(id);

                if (car != null)
                {
                    car.Brand = request.Brand;
                    car.RegistrationNumber = request.RegistrationNumber;
                    car.Color = request.Color;

                    await dbContext.SaveChangesAsync();

                    return Ok(car);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] Guid id)
        {
            try
            {
                Car car = await dbContext.Cars.FindAsync(id);

                if (car != null)
                {
                    dbContext.Remove(car);
                    await dbContext.SaveChangesAsync();

                    return Ok(car);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Public Action Results
    }
}
