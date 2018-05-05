using Microsoft.AspNetCore.Mvc;
using whHireCar.Domain;

namespace whHireCar.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICarService _service;

        public CustomersController(ICarService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetCustomers());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _service.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _service.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
