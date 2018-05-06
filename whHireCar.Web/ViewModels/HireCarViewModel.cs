using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whHireCar.Common;
using whHireCar.Domain;

namespace whHireCar.Web.ViewModels
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
