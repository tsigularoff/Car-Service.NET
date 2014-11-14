namespace CarService.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Linq;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    using CarService.Data;
    using CarService.Models;
    using CarService.Web.Areas.Administration.ViewModels;
   
    public class CarServicesController : AdminController
    {

        public CarServicesController(ICarServiceData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCarServicesForServiceCenter([DataSourceRequest]DataSourceRequest request, int serviceCenterId)
        {
            var services = this.data.CarServiceCenters
                .All()
                .FirstOrDefault(x => x.Id == serviceCenterId)
                .CarServices
                .AsQueryable()
                .Project()
                .To<CarServiceViewModel>();

            return Json(services.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCarServiceFromServiceCenter([DataSourceRequest]DataSourceRequest request, CarServiceViewModel carServiceModel, int serviceCenterId)
        {
            if (carServiceModel != null && ModelState.IsValid)
            {
                var serviceCenter = this.data.CarServiceCenters
                    .All()
                    .FirstOrDefault(x => x.Id == serviceCenterId);

                var carService = this.data.CarServices
                    .All()
                    .FirstOrDefault(x => x.Id == carServiceModel.CarServiceId);

                serviceCenter.CarServices.Remove(carService);
                this.data.SaveChanges();
            }

            return Json(new[] { carServiceModel }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public JsonResult CreateCarServiceForServiceCenter([DataSourceRequest]DataSourceRequest request, CarServiceViewModel carServiceModel, int serviceCenterId)
        {
            var serviceName = carServiceModel.Name;
            var carModelName = carServiceModel.CarModelName;
            var year = carServiceModel.Year;

            var carModelId = this.data.CarModels
                .All()
                .FirstOrDefault(x => x.Name == carModelName && x.Year == year)
                .Id;

            var carService = this.data.CarServices
                .All()
                .FirstOrDefault(x => (x.Name == serviceName) && (x.CarModelId == carModelId));

            if (carService == null)
            {
                carService = new CarService();
                Mapper.Map(carServiceModel, carService);
                carService.CarModelId = carModelId;
                carService.CreatedOn = DateTime.Now;
                carService.ModifiedOn = DateTime.Now;
            }

            var serviceCenter = this.data.CarServiceCenters.Find(serviceCenterId);

            serviceCenter.CarServices.Add(carService);
            this.data.SaveChanges();

            return Json(new[] { carServiceModel }.ToDataSourceResult(request, ModelState));
        }
    }
}