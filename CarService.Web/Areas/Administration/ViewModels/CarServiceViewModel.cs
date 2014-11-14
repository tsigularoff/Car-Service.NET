namespace CarService.Web.Areas.Administration.ViewModels
{
    using CarService.Web.Infrastucture.Mapping;
    using CarService.Models;
    using AutoMapper;
    public class CarServiceViewModel : IMapFrom<CarService>, IHaveCustomMappings
    {
        public int CarServiceId { get; set; }

        public string Name { get; set; }

        public int CarModelId { get; set; }              

        public string CarModelName { get; set; }

        public string Manufacturer { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }        

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CarService, CarServiceViewModel>()
                .ForMember(x=> x.CarServiceId, opt=> opt.MapFrom(u=> u.Id))
                .ForMember(x => x.CarModelName, opt => opt.MapFrom(u => u.CarModel.Name))
                .ForMember(x => x.Year, opt => opt.MapFrom(u => u.CarModel.Year))
                .ForMember(x=> x.Manufacturer, opt => opt.MapFrom(u => u.CarModel.Manufacturer.Name));
        }
    }
}