namespace CarService.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Kendo.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using AutoMapper.QueryableExtensions;

    using CarService.Data;
    using CarService.Web.Areas.Administration.ViewModels;

    public class CarModelsController : AdminController
    {

        public CarModelsController(ICarServiceData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCarModels([DataSourceRequest]DataSourceRequest request)
        {
            var carModels = this.data.CarModels
                .All()
                .Project()
                .To<CarViewModel>();

            return Json(carModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}