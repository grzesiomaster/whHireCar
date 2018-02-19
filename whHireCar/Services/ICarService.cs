using whHireCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whHireCar.Services
{
    public interface ICarService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int? id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);

        IEnumerable<Brand> GetBrands();
        Brand GetBrandById(int? id);
        void AddBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
        
        IEnumerable<Car> GetCars(bool? isHired = null);
        IEnumerable<Car> GetCarsByBrand(int brandId, bool IsHired = false);
        Car GetCardById(int? id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);

        IEnumerable<Hire> GetCurrntHired();
        IEnumerable<Hire> GetHireStory();
        Hire GetHireById(int? id);
        void ReturnCar(Hire rent);
        void AddHire(Hire rent);
    }
}
