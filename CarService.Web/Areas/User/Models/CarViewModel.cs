namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;    
    using CarService.Models;

    public class CarViewModel : IMapFrom<CarModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string NameAndYear
        {
            get { return string.Format("{0} {1}", this.Name, this.Year); }
        }
    }
}