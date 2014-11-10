namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;
    using CarService.Models;
    using System.ComponentModel.DataAnnotations;

    public class CarServiceInputViewModel 
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can be no longer than 50 characters")]
        [MinLength(10, ErrorMessage = "Name can be no shorter than 10 characters")]
        public string Name { get; set; }

        public string CarModelName { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int ServiceCenterId { get; set; }
    }
}