using whHireCar.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whHireCar.ViewModels
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customer HiringCustomer { get; set; }
        public Car HiredCar { get; set; }
    }
}
