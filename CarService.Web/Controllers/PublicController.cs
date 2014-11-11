namespace CarService.Web.Controllers
{    
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarService.Data;
    using CarService.Web.Models;
    

    public class PublicController : BaseController
    {
        public PublicController(ICarServiceData data)
            :base(data)
        {
        }

        public JsonResult GetServiceCenters([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.data.CarServiceCenters
                .All()                
                .Project().To<ServiceCenterViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiceCenters()
        {
            return View();
        }

        public ActionResult ServiceCenterDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ServiceCenters", "Public");
            }

            var serviceCenter = this.data.CarServiceCenters
                .All()
                .Project().To<ServiceCenterViewModel>()
                .FirstOrDefault(x => x.Id == id);

            if (serviceCenter == null)
            {
                return RedirectToAction("ServiceCenters", "Public");
            }

            return View(serviceCenter);
        }
    }
}