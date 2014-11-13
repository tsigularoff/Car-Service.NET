namespace CarService.Models
{
    using System;
    using System.Collections.Generic;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.CarModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
