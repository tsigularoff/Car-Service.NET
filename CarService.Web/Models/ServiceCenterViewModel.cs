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

        public string ImgUrl { get; set; }       
    }
}