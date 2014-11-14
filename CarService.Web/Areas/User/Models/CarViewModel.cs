namespace CarService.Web.Areas.User.Models
{
    using CarService.Web.Infrastucture.Mapping;
    using CarService.Models;
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel : IMapFrom<CarModel>
    {
        public int Id { get; set; }

        [Display(Name = "Car model")]
        public string Name { get; set; }

        [Display(Name = "Car model year")]
        public int Year { get; set; }

        [Display(Name = "Car model and year")]
        public string NameAndYear
        {
            get { return string.Format("{0} {1}", this.Name, this.Year); }
        }
    }
}