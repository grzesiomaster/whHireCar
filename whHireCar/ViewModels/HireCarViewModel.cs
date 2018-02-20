using whHireCar.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whHireCar.ViewModels
{
    public class HireCarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public int? UserId { get; set; }
        public int? CarId { get; set; }
    }
}
