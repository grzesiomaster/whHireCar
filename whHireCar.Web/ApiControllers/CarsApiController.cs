﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Domain;

namespace whHireCar.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    public class CarsApiController : Controller
    {
        private readonly ICarService _service;

        public CarsApiController(ICarService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _service.GetCars();
        }

        [HttpGet("{id}")]
        public IActionResult GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var car = _service.GetCardById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult PutCar([FromRoute] int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != car.Id)
            {
                return BadRequest();
            }
            _service.UpdateCar(car);
            return NoContent();
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.AddCar(car);
            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var car = _service.GetCardById(id);
            if (car == null)
            {
                return NotFound();
            }
            _service.DeleteCar(id);
            return Ok(car);
        }
    }
}