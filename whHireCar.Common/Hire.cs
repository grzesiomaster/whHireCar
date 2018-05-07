using System;
using System.Collections.Generic;
using System.Text;

namespace whHireCar.Common
{
    public class Hire
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public virtual Customer HiringCustomer{ get; set; }
        public virtual Car HiredCar{ get; set; }
    }
}
