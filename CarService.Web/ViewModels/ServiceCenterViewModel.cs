namespace CarService.Web.ViewModels
{
    using AutoMapper;
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceCenterViewModel : IMapFrom<CarServiceCenter>
    {        
        public int Id;

        [Display(Name="Service Center")]
        public string Name { get; set; }

        [Display(Name="Street Address")]
        public string StreetAddress { get; set; }

        public string ImgUrl { get; set; }       
    }
}