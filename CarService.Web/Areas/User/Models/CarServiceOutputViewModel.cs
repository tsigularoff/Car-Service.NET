namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;

    using CarService.Models;

    public class CarServiceOutputViewModel : IMapFrom<CarService>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CarModelId { get; set; }
    }
}