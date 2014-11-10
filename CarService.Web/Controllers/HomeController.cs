namespace CarService.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using CarService.Data;
    using CarService.Web.Models;

    public class HomeController : BaseController
    {
        public HomeController(ICarServiceData data)
            :base(data)
        {
        }

        //[OutputCache(Duration=10, VaryByParam="none")]       
        public ActionResult Index()
        {
            var serviceCentersCount = this.data.CarServiceCenters.All().Count();
            var regUsersCount = this.data.Users.All().Count();
            var carServiceCount = this.data.CarServices.All().Count();
            var manufaturersCount = this.data.Manufacturers.All().Count();
            var carModelsCount = this.data.CarModels.All().Count();

            var homeViewInfo = new HomeViewModel
            {
                ServiceCentersCount = serviceCentersCount,
                RegisterUsersCount = regUsersCount,
                CarServicesCount = carServiceCount,
                CarModelsCount = carModelsCount,
                ManufacturersCount = manufaturersCount
            };

            return View(homeViewInfo);
        }        

        public ActionResult Contact()
        {           
            return View();
        }
    }
}