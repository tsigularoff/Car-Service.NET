namespace CarService.Web.Controllers
{    
    using System.Web.Mvc;

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
    }
}