namespace CarService.Web.Areas.User.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarServiceCenterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        [StringLength(30, ErrorMessage="Name can be no longer than 30 characters")]
        [MinLength(3, ErrorMessage="Name can be no shorter than 3 characters")]
        [Display(Name = "Service Center Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [StringLength(40, ErrorMessage = "Street address can be no longer than 40 characters")]
        [MinLength(10, ErrorMessage = "Street address can be no shorter than 10 characters")]   
        [Display(Name="Street Address")]
        public string StreetAddress { get; set; }

        public string Location { get; set; }
    }
}