namespace CarService.Models
{
    using System.Collections.Generic;

    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
