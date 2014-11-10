namespace CarService.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using CarService.Web.Controllers;
    using CarService.Data;
    using CarService.Web.Areas.User.Models;
    using CarService.Models;

    using AutoMapper.QueryableExtensions;

    public class ServiceCenterController : UserAreaController
    {
        private const string SuccessMessage = "Service center created!";

        public ServiceCenterController(ICarServiceData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddServiceCenter(CarServiceCenterViewModel serviceCenterModel)
        {
            if (ModelState.IsValid)
            {
                var serviceCenter = new CarServiceCenter
                {
                    Name = serviceCenterModel.Name,
                    StreetAddress = serviceCenterModel.StreetAddress
                };

                this.data.CarServiceCenters.Add(serviceCenter);
                this.data.SaveChanges();

                TempData["message"] = SuccessMessage;
                TempData["serviceCenterName"] = serviceCenter.Name;
                return RedirectToAction("AddCarService");
            }

            return View("Index", serviceCenterModel);
        }

        public ActionResult AddCarService()
        {
            var manufacturers = this.data.Manufacturers
                .All()
                .OrderBy(x => x.Name)
                .Project().To<ManufacturerViewModel>();

            return View(manufacturers);
        }

        public JsonResult GetServiceCenters()
        {
            var serviceCenters = this.data.CarServiceCenters
                .All()
                .OrderBy(x => x.Name)
                .Select(x => new { Name = x.Name, Id = x.Id });

            return Json(serviceCenters, JsonRequestBehavior.AllowGet);
        }

       
    }
}