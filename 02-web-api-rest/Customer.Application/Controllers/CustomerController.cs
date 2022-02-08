using Customer.Application.Commands;
using Customer.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Customer.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerDataBase _customerDataBase;

        public CustomerController(ILogger<CustomerController> logger, ICustomerDataBase customerDataBase)
        {
            this._logger = logger;
            this._customerDataBase = customerDataBase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this._logger.LogInformation("Calling {method}", nameof(Get));

            var result = this._customerDataBase.GetAll();

            if (result is null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{uid}")]
        public IActionResult GetById(string uid)
        {
            this._logger.LogInformation("Calling {method} with {uid}", nameof(Get), uid);

            CustomerFullInformation result = this._customerDataBase.GetById(uid);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomer customer)
        {
            this._logger.LogInformation("Calling {method} with {customer}", nameof(Create), JsonConvert.SerializeObject(customer));

            if (customer is null)
            {
                return BadRequest();
            }

            Entities.Customer customerCreated = this._customerDataBase.Add(customer);

            return CreatedAtAction(null, customerCreated);
        }

        [HttpPut("{uid}")]
        public IActionResult Update(string uid, [FromBody] UpdateCustomer customer)
        {
            this._logger.LogInformation("Calling {method} with {customer}", nameof(Update), JsonConvert.SerializeObject(customer));

            if (customer is null)
            {
                return BadRequest();
            }

            var customerToUpdate = customer with { uid = uid };

            var customerUpdated = this._customerDataBase.Update(customerToUpdate);

            return Ok(customerUpdated);
        }

        [HttpDelete("{uid}")]
        public IActionResult Delete(string uid)
        {
            this._logger.LogInformation("Calling {method} with {uid}", nameof(Delete), uid);

            if (string.IsNullOrEmpty(uid))
            {
                return BadRequest();
            }

            this._customerDataBase.Delete(uid);

            return Ok();
        }
    }
}
