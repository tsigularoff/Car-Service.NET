namespace CarService.Web.Areas.Administration.ViewModels
{
    using System;
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;    

    public class ManufacturerViewModel : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}