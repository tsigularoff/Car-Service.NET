namespace CarService.Models
{
    using System.Collections.Generic;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.CarModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
