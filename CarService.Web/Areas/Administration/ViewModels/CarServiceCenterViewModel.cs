namespace CarService.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarService.Web.Infrastucture.Mapping;

    using CarService.Models;
    using System.Web.Mvc;
    using System.Collections.Generic;

    public class CarServiceCenterViewModel : IMapFrom<CarServiceCenter>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? ServiceCenterId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can be no longer than 30 characters")]
        [MinLength(3, ErrorMessage = "Name can be no shorter than 3 characters")]
        [Display(Name = "Service Center Name")]
        public string Name { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [StringLength(40, ErrorMessage = "Street address can be no longer than 40 characters")]
        [MinLength(10, ErrorMessage = "Street address can be no shorter than 10 characters")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
                
        public string ImgUrl { get; set; }

        public ICollection<CarServiceViewModel> CarServices { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<CarServiceCenter, CarServiceCenterViewModel>()
                .ForMember(x => x.ServiceCenterId, opt => opt.MapFrom(x => x.Id));
        }
    }
}