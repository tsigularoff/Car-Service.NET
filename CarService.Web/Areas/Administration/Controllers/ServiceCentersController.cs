namespace CarService.Web.Areas.Administration.Controllers
{    
    using System.Web.Mvc;
    using System.Linq;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CarService.Data;
    using CarService.Web.Areas.Administration.ViewModels;
    using CarService.Models;

    public class ServiceCentersController : AdminController
    {
        public ServiceCentersController(ICarServiceData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetServiceCenters([DataSourceRequest]DataSourceRequest request)
        {
            var serviceCenters = this.data.CarServiceCenters
                .All()
                .Project().To<CarServiceCenterViewModel>();

            return Json(serviceCenters.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateServiceCenter([DataSourceRequest]DataSourceRequest request, CarServiceCenterViewModel serviceCenterModel)
        {
            if (serviceCenterModel != null && ModelState.IsValid)
            {
                var serviceCenter = this.data.CarServiceCenters
                    .All()
                    .FirstOrDefault(x => x.Id == serviceCenterModel.Id);

                Mapper.Map(serviceCenterModel, serviceCenter);

                this.data.SaveChanges();
            }

            return Json(new[] { serviceCenterModel }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public JsonResult DeleteServiceCenter([DataSourceRequest]DataSourceRequest request, CarServiceCenterViewModel serviceCenterModel)
        {
            if (serviceCenterModel != null && ModelState.IsValid)
            {
                var serviceCenter = this.data.CarServiceCenters
                    .All()
                    .FirstOrDefault(x => x.Id == serviceCenterModel.Id);

                this.data.CarServiceCenters.Delete(serviceCenter);
                
                this.data.SaveChanges();
            }

            return Json(new[] { serviceCenterModel }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public JsonResult CreateServiceCenter([DataSourceRequest]DataSourceRequest request, CarServiceCenterViewModel serviceCenterModel)
        {
            if (serviceCenterModel != null && ModelState.IsValid)
            {
                var serviceCenter = new CarServiceCenter();
                Mapper.Map(serviceCenterModel, serviceCenter);

                this.data.CarServiceCenters.Add(serviceCenter);
                this.data.SaveChanges();
            }

            return Json(new[] { serviceCenterModel }.ToDataSourceResult(request, ModelState));
        }
    }
}