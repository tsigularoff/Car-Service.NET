namespace CarService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;    

    public class CarServiceCenter
    {
        public CarServiceCenter()
        {
            this.CarServices = new HashSet<CarService>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public string StreetAddress { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ImgUrl { get; set; }        

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<CarService> CarServices { get; set; }        
    }
}
