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
    public class BrandsController : Controller
    {
        private readonly ICarService _service;

        /////////////////////////////////////////////////////////////////////////////
        // constructor
        public BrandsController(ICarService service)
        {
            _service = service;
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Index()
        {
            return View(_service.GetBrands());
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }           
            var brand = _service.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Create()
        {
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _service.AddBrand(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = _service.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _service.UpdateBrand(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = _service.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        /////////////////////////////////////////////////////////////////////////////
        //
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteBrand(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
