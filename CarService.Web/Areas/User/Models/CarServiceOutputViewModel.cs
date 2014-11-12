namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;

    using CarService.Models;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class CarServiceOutputViewModel : IMapFrom<CarService>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Service Name")]
        public string Name { get; set; }

        [Display(Name = "Service Price")]
        public decimal Price { get; set; }

        public int CarModelId { get; set; }

        [Display(Name = "Car Model")]
        public string CarModelName { get; set; }

        [Display(Name = "Car Model Year")]
        public int CarModelYear { get; set; }

        [Display(Name = "Car Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Car Model")]
        public string CarModelFullName
        {
            get { return (string.Format("{0} {1}", this.Manufacturer, this.CarModelName)); }
        }

        [Display(Name = "Service Center")]
        public ICollection<CarServiceCenterViewModel> ServiceCenters { get; set; }

        [Display(Name = "Distance to service center")]
        public double DistanceTo { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CarService, CarServiceOutputViewModel>()
                .ForMember(m => m.CarModelName, opt => opt.MapFrom(u => u.CarModel.Name))
                .ForMember(m => m.CarModelYear, opt => opt.MapFrom(u => u.CarModel.Year))
                .ForMember(m => m.Manufacturer, opt => opt.MapFrom(u => u.CarModel.Manufacturer.Name))
                 .ForMember(m => m.ServiceCenters, opt => opt.MapFrom(u => u.CarServiceCenters));
        }
    }
}