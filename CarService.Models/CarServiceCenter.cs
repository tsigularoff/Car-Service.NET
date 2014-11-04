using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarServiceCenter
    {
        public CarServiceCenter()
        {
            this.SupportedCars = new HashSet<CarModel>();
            this.SupportedServices = new HashSet<CarService>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string StreetAddress { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<CarModel> SupportedCars { get; set; }

        public virtual ICollection<CarService> SupportedServices { get; set; }
    }
}
