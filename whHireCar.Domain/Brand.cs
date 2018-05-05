using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace whHireCar.Domain
{
    public class Brand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
