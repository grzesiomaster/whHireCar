using whHireCar.Data;
using Microsoft.EntityFrameworkCore;
using whHireCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whHireCar.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBrand(Brand brand)
        {
            _context.Add(brand);
            _context.SaveChanges();
        }

        public void AddCar(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var brand = _context.Brands.FirstOrDefault(m => m.Id == id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var carx = _context.Cars.FirstOrDefault(m => m.Id == id);
            _context.Cars.Remove(carx);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(m => m.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Brand GetBrandById(int? id)
        {
            return _context.Brands.FirstOrDefault(m => m.Id == id);
           
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.AsEnumerable();
        }

        public Car GetCardById(int? id)
        {
            return _context.Cars
                        .Include(x => x.Brand)
                        .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Car> GetCars(bool? isHired = null)
        {
            if (isHired.HasValue)
            {
                return _context.Cars
                            .Where(x => x.IsHired == isHired)
                            .AsEnumerable();
            }
            else
            {
                return _context.Cars
                            .Include(x => x.Brand)
                            .AsEnumerable();
            }
        }

        public Customer GetCustomerById(int? id)
        {
            return _context.Customers.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.AsEnumerable();
        }

        public void UpdateBrand(Brand brand)
        {

            _context.Update(brand);
            _context.SaveChanges();

        }

        public void UpdateCar(Car car)
        {
            _context.Update(car);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
             _context.Update(customer);
             _context.SaveChanges();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }

        public IEnumerable<Car> GetCarsByBrand(int brandId, bool isHired = false)
        {
            IEnumerable<Car> Cars;
            if (brandId > 0)
            {
                Cars = _context.Cars
                            .Include(x => x.Brand)
                            .Where(x => x.IsHired == isHired && x.Brand.Id == brandId)
                            .AsEnumerable();
            }
            else
            {
                Cars = _context.Cars
                            .Include(x => x.Brand)
                            .Where(x => x.IsHired == isHired)
                            .AsEnumerable();
            }
            return Cars;
        }

        public IEnumerable<Hire> GetHireStory()
        {
            return _context.Hires
                        .Include(x => x.HiringCustomer)
                        .Include(x => x.HiredCar)
                        .ThenInclude(x => x.Brand)
                        .AsEnumerable();
        }

        private bool RentExists(int id)
        {
            return _context.Hires.Any(e => e.Id == id);
        }

        public void AddHire(Hire rent)
        {
            _context.Add(rent);
            _context.SaveChanges();
        }

        public void ReturnCar(Hire rent)
        {
            int carId = _context.Hires
                              .Where(y => y.Id == rent.Id)
                              .Select(z => z.HiredCar.Id)/*.Cast<int>()*/
                              .FirstOrDefault();
            var car = _context.Cars
                            .Where(x => x.Id == carId)
                            .SingleOrDefault();
            car.IsHired = false;
            _context.Update(car);
            _context.Update(rent);
            _context.SaveChanges();

        }

        public Hire GetHireById(int? id)
        {
            if (id.HasValue)
            {
                return _context.Hires
                            .Include(x => x.HiringCustomer)
                            .Include(x => x.HiredCar)
                            .ThenInclude(x => x.Brand)
                            .SingleOrDefault(m => m.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Hire> GetCurrntHired()
        {
            return  _context.Hires
                        .Include(x => x.HiringCustomer)
                        .Include(x => x.HiredCar)
                        .ThenInclude(x => x.Brand)
                        .Where(x => x.ReturnDate == null)
                        .AsEnumerable();
        }
    }
}
