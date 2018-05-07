using System.ComponentModel.DataAnnotations;

namespace whHireCar.Common
{
    public class Car
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Enter number")]
        //[StringLength(10)]
        public string Number { get; set; }
        //[Required(ErrorMessage = "Enter Model")]
        //[StringLength(50)]
        public string Model { get; set; }
        public virtual Brand Brand { get; set; }
        public bool IsHired { get; set; }
    }
}
