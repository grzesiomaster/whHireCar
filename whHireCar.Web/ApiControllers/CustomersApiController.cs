using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Common;
using whHireCar.Domain;

namespace whHireCar.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersApiController : Controller
    {
        private readonly ICarService _service;

        public CustomersApiController( ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _service.GetCustomers();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.Id)
            {
                return BadRequest();
            }
            try
            {
                _service.UpdateCustomer(customer);
            }
            catch(Exception ex)
            {
                throw;
            }           
            return NoContent();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.UpdateCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            _service.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}