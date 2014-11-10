namespace CarService.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using CarService.Web.Controllers;
    using CarService.Data;
    using CarService.Web.Areas.User.Models;
    using CarService.Web.Infrastucture;

    public class CarsController : BaseController
    {

        public CarsController(ICarServiceData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetModelsByManufacturer(int? manufacturerId)
        {
            var models = this.data.CarModels
                                .All()
                                .Where(x => x.ManufacturerId == manufacturerId)
                                .OrderBy(x => x.Name)
                                .Project().To<CarViewModel>()
                                .DistinctBy(x => x.Name);

            return this.Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetModelYears(string modelName)
        {
            var modelYears = this.data.CarModels
                .All()
                .Where(x => x.Name == modelName)
                .Select(x => x.Year);
                       
            return this.Json(modelYears, JsonRequestBehavior.AllowGet);
        }

       
    }
}