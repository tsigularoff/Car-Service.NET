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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarService(CarServiceInputViewModel carServiceModel)
        {
            if (!this.ModelState.IsValid)
            {
                TempData["errorMessage"] = "Car service length must be between 10 and 50 characters";

                return RedirectToAction("AddCarService", "ServiceCenter");
            }

            var carModelName = carServiceModel.CarModelName;
            var year = carServiceModel.Year;

            var carModelId = this.data.CarModels
                .All()
                .FirstOrDefault(x => x.Name == carModelName && x.Year == year)
                .Id;

            var carService = new CarService
            {
                Name = carServiceModel.Name,
                CarModelId = carModelId,
                Price = carServiceModel.Price
            };

            var serviceCenter = this.data.CarServiceCenters.Find(carServiceModel.ServiceCenterId);

            serviceCenter.CarServices.Add(carService);
            this.data.SaveChanges();

            TempData["successMessage"] = "Service successfully added!";

            return RedirectToAction("AddCarService", "ServiceCenter");
        }

        public JsonResult CarModelServices(string modelName, int year)
        {
            var carModelId = this.data.CarModels
                .All()
                .FirstOrDefault(x => x.Name == modelName && x.Year == year)
                .Id;

            var modelServices = this.data.CarServices
                .All()
                .Where(x => x.CarModelId == carModelId)
                .Project().To<CarServiceOutputViewModel>()
                .ToList();

            return Json(modelServices, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServiceCenterServices([DataSourceRequest]DataSourceRequest request, int id)
        {
            var result = this.data.CarServiceCenters
                .All()
                .FirstOrDefault(x=> x.Id == id)
                .CarServices
                .AsQueryable()
                .Project().To<CarServiceOutputViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}