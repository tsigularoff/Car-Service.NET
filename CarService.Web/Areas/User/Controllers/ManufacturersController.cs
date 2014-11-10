namespace CarService.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using CarService.Web.Controllers;
    using CarService.Data;
    using CarService.Web.Areas.User.Models;
    using AutoMapper.QueryableExtensions;

    public class ManufacturersController : BaseController
    {
        public ManufacturersController(ICarServiceData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetManufacturers()
        {
            var manufacturers = this.data.Manufacturers
                .All()
                .OrderBy(x => x.Name)
                .Project().To<ManufacturerViewModel>();

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }
    }
}