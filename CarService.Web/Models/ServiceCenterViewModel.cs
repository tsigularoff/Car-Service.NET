namespace CarService.Web.Models
{
    using CarService.Models;
    using CarService.Web.Infrastucture.Mapping;

    public class ServiceCenterViewModel : IMapFrom<CarServiceCenter>
    {
        public int Id;

        public string Name { get; set; }

        public string StreetAddress { get; set; }
    }
}