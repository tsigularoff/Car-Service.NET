namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;
    using CarService.Models;

    public class ManufacturerViewModel : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}