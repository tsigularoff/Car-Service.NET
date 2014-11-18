namespace CarService.Web.Areas.User.Models
{
    using AutoMapper;
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarServiceCenterViewModel : IMapFrom<CarServiceCenter>
    {       
        public int Id { get; set; }

        [Display(Name = "Service Center Name")]
        [Required(ErrorMessage="Name is required")]
        [StringLength(30, MinimumLength=3, ErrorMessage="Name length must be between 3 and 30 characters")]
        [RegularExpression("[\\sa-zA-Z0-9а-яА-я\\.]+", ErrorMessage = "Allowed characters : 'a-z', 'A-Z', '0-9', '.'")]
        public string Name { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street address is required")]
        [StringLength(40, MinimumLength=10, ErrorMessage = "Street address can be no longer than 40 characters")]
        [RegularExpression("[\\sa-zA-Z0-9а-яА-я\\.]+", ErrorMessage = "Allowed characters : 'a-z', 'A-Z', '0-9', '.'")]    
        public string StreetAddress { get; set; }

        public string Location { get; set; }

        public double DistanceTo { get; set; }

        public string ImgUrl { get; set; }
    }
}