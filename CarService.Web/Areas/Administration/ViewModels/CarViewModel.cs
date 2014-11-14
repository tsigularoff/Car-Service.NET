namespace CarService.Web.Areas.Administration.ViewModels
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using CarService.Web.Infrastucture.Mapping;

    using CarService.Models;

    public class CarViewModel : IMapFrom<CarModel>, IHaveCustomMappings
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Car model name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model name length must be between 2 and 20 characters")]
        [Display(Name = "Car Model")]
        public string Name { get; set; }

        public int Year { get; set; }

        public int ManufacturerId { get; set; }

        public string Manufacturer { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CarModel, CarViewModel>()
                .ForMember(x=> x.Manufacturer, opt => opt.MapFrom(u => u.Manufacturer.Name));
        }
    }
}