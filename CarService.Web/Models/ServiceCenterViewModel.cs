namespace CarService.Web.Models
{
    using AutoMapper;
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;
    using System.Collections.Generic;

    public class ServiceCenterViewModel : IMapFrom<CarServiceCenter>
    {
        public int Id;

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        //public ICollection<CarService> CarServices { get; set; }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<CarServiceCenter, ServiceCenterViewModel>()
        //        .ForMember(m => m.CarServices, opt => opt.MapFrom(u => u.Category.Name.ToString()));

        //    configuration.CreateMap<Campaign, ListCampaignsDetailsViewModel>()
        //        .ForMember(m => m.CompanyName, opt => opt.MapFrom(u => u.Owner.CompanyName));
        //}
    }
}