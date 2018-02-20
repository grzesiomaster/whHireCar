using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whHireCar.Data;
using whHireCar.Models;
using whHireCar.ViewModels;
using whHireCar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace whHireCar.Controllers
{
    public class HireCarController : Controller
    {
        private readonly ICarService _service;

        public HireCarController(ICarService service)
        {
            _service = service;
        }

        public IActionResult HireStory()
        {
            var rentStory = _service.GetHireStory();
            return View(rentStory);
        }

        public IActionResult ReturnCar()
        {
            var rented = _service.GetCurrntHired();
            return View(rented);
        }

        public IActionResult Index()
        {
            return RedirectToAction("ReturnCar");
        }

        public IActionResult HireCar()
        {
            HireCarViewModel hirevm = new HireCarViewModel();
            hirevm.Cars = _service.GetCars(false);
            hirevm.Brands = _service.GetBrands();
            hirevm.Customers = _service.GetCustomers();
            return View(hirevm);
        }

        public JsonResult ChangeBrand(int id)
        {
            IEnumerable<Car> Cars = _service.GetCarsByBrand(id);
            return Json(new SelectList(Cars,"Id","Model"));
        }

        public JsonResult LoadBrands()
        {
            IEnumerable<Brand> Brands;
            Brands = _service.GetBrands();
            return Json(new SelectList(Brands, "Id", "Name"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CarId,UserId")] HireCarViewModel postModel)
        {
            if (ModelState.IsValid && postModel.UserId.HasValue && postModel.CarId.HasValue)
            {
                Car car = _service.GetCardById(postModel.CarId);
                car.IsHired = true;
                Hire rent = new Hire();
                rent.HireDate = DateTime.Now;
                rent.HiredCar = _service.GetCardById(postModel.CarId);
                rent.HiringCustomer = _service.GetCustomerById(postModel.UserId);

                _service.UpdateCar(car);
                _service.AddHire(rent);
                return RedirectToAction("ReturnCar");
            }
            else
            {
				//TODO requierd message containing info validation fail
                return RedirectToAction("HireCar"); 
            }
        }

        public IActionResult Return(int? id)
        {
            var rent = _service.GetHireById(id);
            rent.ReturnDate = DateTime.Now;
            return View(rent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return(int id, [Bind("Id,HireDate,ReturnDate")] Hire rent)
        {
            if (id != rent.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _service.ReturnCar(rent); 
                }
                catch (DbUpdateConcurrencyException)
                {
                     throw;
                }
                return RedirectToAction("ReturnCar");
            }
            return View(rent);
        }
    }
}