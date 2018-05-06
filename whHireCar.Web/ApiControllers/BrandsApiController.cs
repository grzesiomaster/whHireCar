using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Common;
using whHireCar.Domain;

namespace whHireCar.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsApiController : Controller
    {
        private readonly ICarService _service;
                
        public BrandsApiController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Brand> GetBrands()
        {
            return _service.GetBrands();
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brand = _service.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public IActionResult PutBrand([FromRoute] int id, [FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _service.UpdateBrand(brand);
            return NoContent();
        }

        [HttpPost]
        public IActionResult PostBrand([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.UpdateBrand(brand);
            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brand = _service.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            _service.DeleteBrand(id);
            return Ok(brand);
        }
    }
}