using Microsoft.AspNetCore.Mvc;
using RentalCars.Domain.Commands;
using RentalCars.Domain.Services;

namespace RentalCars.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this._carService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this._carService.Get(id);

            return Ok(result);
        }

        [HttpGet("brand/{brand}")]
        public IActionResult Get(string brand)
        {
            var result = this._carService.GetByBrand(brand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteCar = new DeleteCar() { Id = id };

            this._carService.Delete(deleteCar);

            return Ok(deleteCar);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCar car)
        {
            var result = this._carService.Create(car);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateCar car)
        {
            var result = this._carService.Update(car);

            return Ok(result);
        }
    }
}
