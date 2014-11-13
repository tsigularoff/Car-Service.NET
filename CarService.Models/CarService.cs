namespace CarService.Models
{
    using System;
using System.Collections.Generic;

    public class CarService
    {
        public CarService()
        {
            this.CarServiceCenters = new HashSet<CarServiceCenter>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CarModelId { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual CarModel CarModel { get; set; }        

        public virtual ICollection<CarServiceCenter> CarServiceCenters { get; set; }
    }
}
