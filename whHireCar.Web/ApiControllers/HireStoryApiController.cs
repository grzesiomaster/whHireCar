using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Common;
using whHireCar.Domain;

namespace whHireCar.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/HireStory")]
    public class HireStoryApiController : Controller
    {
        private readonly ICarService _service;

        public HireStoryApiController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Hire> HireStory()
        {
            return _service.GetHireStory();
        }
    }
}
