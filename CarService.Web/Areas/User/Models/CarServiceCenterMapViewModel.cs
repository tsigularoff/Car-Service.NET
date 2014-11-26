namespace CarService.Web.Areas.User.Models
{
    using AutoMapper;
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;

    public class CarServiceCenterMapViewModel : IMapFrom<CarServiceCenter>
    {       
        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string Location { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}