using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Common;
using whHireCar.Domain;

namespace whHireCar.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/HireCar")]
    public class HireCarApiController : Controller
    {
        private readonly ICarService _service;

        public HireCarApiController(ICarService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetRents")]
        public IEnumerable<Hire> GetRents()
        {
            return _service.GetCurrntHired();
        }

        [HttpGet("{id}")]
        public IActionResult GetRent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rent = _service.GetHireById(id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
        }

        [HttpPost]
        public IActionResult PostRent([FromBody] Hire rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.AddHire(rent);
            return CreatedAtAction("GetRent", new { id = rent.Id }, rent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rent = _service.GetHireById(id);
            if (rent == null)
            {
                return NotFound();
            }
            _service.ReturnCar(rent);
            return Ok(rent);
        }
    }
}