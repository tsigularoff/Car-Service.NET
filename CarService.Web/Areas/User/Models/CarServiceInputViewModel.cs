namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;
    using CarService.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

  
    public class CarServiceInputViewModel
    {
        
        [AllowHtml]
        [Display(Name = "Car Service Name")]
        [Required(ErrorMessage = "Service name is required!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Car service name must be between 10 and 50 characters!")]
        [RegularExpression("[\\sa-zA-Z0-9а-яА-я\\.]+", ErrorMessage = "Allowed characters : 'a-z', 'A-Z', '0-9', '.'")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Car model is required!")]
        public string CarModelName { get; set; }

        [Required(ErrorMessage = "Car model year is required!")]
        [Range(1920, 2020)]
        public int Year { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Car service center is required!")]
        public int ServiceCenterId { get; set; }
    }
}