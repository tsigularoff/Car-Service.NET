namespace CarService.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarService.Data;
    using CarService.Models;
    using CarService.Web.Areas.User.Models;
    using CarService.Web.Controllers;

    public class CarServiceController : UserAreaController
    {
        public CarServiceController(ICarServiceData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult AddCarService()
        {
            var manufacturers = this.data.Manufacturers
                .All()
                .OrderBy(x => x.Name)
                .Project().To<ManufacturerViewModel>();

            return View(manufacturers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarService(CarServiceInputViewModel carServiceModel)
        {
            if (!this.ModelState.IsValid)
            {
                TempData["errorMessage"] = "Car service length must be between 10 and 50 characters";

                return RedirectToAction("AddCarService", "CarService");
            }

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
            
            if(carService == null)
            {
                carService = new CarService
                {
                    Name = carServiceModel.Name,
                    CarModelId = carModelId,
                    Price = carServiceModel.Price
                };
            }

            var serviceCenter = this.data.CarServiceCenters.Find(carServiceModel.ServiceCenterId);

            serviceCenter.CarServices.Add(carService);
            this.data.SaveChanges();

            TempData["successMessage"] = "Service successfully added!";

            return RedirectToAction("AddCarService", "CarService");
        }

        [HttpGet]
        public ActionResult SearchService()
        {
            return View();
        }       

        public ActionResult ServiceDetails()
        {
            var serviceId = int.Parse(Request.QueryString.GetValues("id")[0]);

            var carService = this.data.CarServices
                                    .All()
                                    .Project().To<CarServiceOutputViewModel>()
                                    .FirstOrDefault(x => x.Id == serviceId);

            return View(carService);
        }

        public JsonResult GetServices([DataSourceRequest]DataSourceRequest request)
        {
            var services = this.data.CarServices
                .All()
                .Project().To<CarServiceOutputViewModel>();

            // For the needs of Autocomplete
            if (request.Filters == null)
            {
                return Json(services, JsonRequestBehavior.AllowGet);
            }

            return Json(services.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServiceCenterServices([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = this.data.CarServiceCenters
                .All()
                .FirstOrDefault(x => x.Id == id)
                .CarServices
                .AsQueryable()
                .Project().To<CarServiceOutputViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}