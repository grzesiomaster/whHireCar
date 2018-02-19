using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using whHireCar.Data;
using whHireCar.Models;

using whHireCar.Services;

namespace whHireCar.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        /////////////////////////////////////////////////////////////////////////////
        // constructor
        public CarsController(ICarService service)
        {
            _service = service;
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Index()
        {
            return View(_service.GetCars());
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _service.GetCardById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Create()
        {
            var brands = _service.GetBrands();
            ViewBag.ListOfBrands = brands;
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            //TODO zrobić poprawnie walidację 
           // if (ModelState.IsValid)
            {
                Car newCar = new Car();
                newCar.Number = car.Number;
                newCar.Model = car.Model;
                newCar.Brand = _service.GetBrandById(car.Brand.Id);

                _service.AddCar(newCar);
                return RedirectToAction(nameof(Index));
            }
            var brands = _service.GetBrands();
            ViewBag.ListOfBrands = brands;
            return View(car);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brands = _service.GetBrands();
            ViewBag.ListOfBrands = brands;
            var car = _service.GetCardById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Car car)
        {
            // TODO zrobić poprawnie walidację
            //if (ModelState.IsValid)
            {
                if (id != car.Id)
                {
                    return NotFound();
                }
                //if VALID
                {
                    var baseCar = _service.GetCardById(id);
                    baseCar.Brand = _service.GetBrandById(car.Brand.Id);
                    baseCar.Model = car.Model;
                    baseCar.Number = car.Number;
                    _service.UpdateCar(baseCar);

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(car);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _service.GetCardById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
