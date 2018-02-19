using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whHireCar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using whHireCar.Models;

namespace hireCar.Web.ApiControllers
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
