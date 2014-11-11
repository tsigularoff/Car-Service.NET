namespace CarService.Web.Areas.User.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarService.Web.Controllers;
    using CarService.Data;
    using CarService.Web.Areas.User.Models;
    using CarService.Models;
    using System;

   

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
                    StreetAddress = serviceCenterModel.StreetAddress,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
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

        public ActionResult ServiceCenters()
        {
            return View();
        }

        public ActionResult ServiceCenterDetails()
        {
            var serviceCenterId = int.Parse(this.Request.QueryString.GetValues("id")[0]);

            var serviceCenter = this.data.CarServiceCenters
                                        .All()
                                        .Project().To<CarServiceCenterViewModel>()
                                        .FirstOrDefault(x => x.Id == serviceCenterId);

            if (serviceCenter == null)
            {
                RedirectToAction("ServiceCenters", "ServiceCenter");
            }

            return View(serviceCenter);
        }

        public JsonResult GetServiceCenters()
        {
            var serviceCenters = this.data.CarServiceCenters
                .All()
                .OrderBy(x => x.Name)
                .Select(x => new { Name = x.Name, Id = x.Id });

            return Json(serviceCenters, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServiceCentersForGrid([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.data.CarServiceCenters
                .All()
                .Project().To<CarServiceCenterViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}