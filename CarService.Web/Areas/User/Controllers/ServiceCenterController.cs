namespace CarService.Web.Areas.User.Controllers
{
    using System;
    using System.IO;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CarService.Web.Controllers;
    using CarService.Data;
    using CarService.Web.Areas.User.Models;
    using CarService.Models;
    using CarService.Web.Common;

    public class ServiceCenterController : UserAreaController
    {
        private const string SuccessMessage = "Service center created!";
        private const string ImagePath = "/Imgs/ServiceCenters";
        private const string DefaulImagePath = "/Imgs/Logos/noimage.jpg";

        public ServiceCenterController(ICarServiceData data)
            : base(data)
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddServiceCenter(CarServiceCenterViewModel serviceCenterModel)
        {
            if (ModelState.IsValid)
            {
                var serviceCenter = new CarServiceCenter();

                Mapper.Map(serviceCenterModel, serviceCenter);

                serviceCenter.CreatedOn = DateTime.Now;
                serviceCenter.ModifiedOn = DateTime.Now;

                this.data.CarServiceCenters.Add(serviceCenter);
                this.data.SaveChanges();

                SaveImage(serviceCenter);

                TempData["successMessage"] = SuccessMessage;
                TempData["serviceCenterName"] = serviceCenter.Name;                

                if (User.Identity.IsAuthenticated)
                {
                    var userId = this.User.Identity.GetUserId();
                    var user = this.data.Users.All().FirstOrDefault(x => x.Id == userId);
                    user.AddedServicesCount++;
                }

                this.data.SaveChanges();
                return RedirectToAction("AddCarService", "CarService");
            }

            return View("Index", serviceCenterModel);
        }

        [HttpGet]
        public ActionResult AddServiceCenter()
        {
            return View();
        }

        public ActionResult ServiceCenters()
        {
            this.CalculateDistances();
            return View();
        }

        public ActionResult ServiceCenterDetails(int id)
        {
            var serviceCenter = this.data.CarServiceCenters
                                        .All()
                                        .Project().To<CarServiceCenterViewModel>()
                                        .FirstOrDefault(x => x.Id == id);

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
                .Project().To<CarServiceCenterViewModel>()
                .ToList();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private void SaveImage(CarServiceCenter serviceCenter)
        {
            var imageName = string.Format("service-center-{0}", serviceCenter.Id);

            if (Request.Files["image"].ContentLength > 0)
            {
                string extension = Path.GetExtension(Request.Files["image"].FileName);
                string imgServerPath = string.Format("{0}/{1}{2}", Server.MapPath(ImagePath), imageName, extension);
                if (System.IO.File.Exists(imgServerPath))
                    System.IO.File.Delete(imgServerPath);

                Request.Files["image"].SaveAs(imgServerPath);
                serviceCenter.ImgUrl = string.Format("{0}/{1}{2}", ImagePath, imageName, extension);
            }
            else
            {
                serviceCenter.ImgUrl = DefaulImagePath;
            }
            this.data.SaveChanges();
        }

        private void CalculateDistances()
        {
            var isUserLocated = false;
            var userLocation = new GeoPoint();

            if (this.Session["userLocation"] != null)
            {
                isUserLocated = true;

                var userLocationAsStrings = this.Session["userLocation"].ToString().Split(new char[] { ';' });
                userLocation.Lat = double.Parse(userLocationAsStrings[0]);
                userLocation.Lng = double.Parse(userLocationAsStrings[1]);                
            }
           

            var serviceCenters = this.data.CarServiceCenters.All();

            foreach (var serviceCenter in serviceCenters)
            {
                var serviceCenterLocationAsStrings = serviceCenter.Location.Split(new char[] { ';' });

                if (isUserLocated)
                {
                    var serviceCenterLocation = new GeoPoint
                    {
                        Lat = double.Parse(serviceCenterLocationAsStrings[0]),
                        Lng = double.Parse(serviceCenterLocationAsStrings[1])
                    };

                    serviceCenter.DistanceTo = GeoDistance.GetDistance(userLocation, serviceCenterLocation);
                }
                else
                {
                    serviceCenter.DistanceTo = 0;
                    TempData["message"] = "Sorry distance to service centers are not available";
                }
            }
            this.data.SaveChanges();
        }
    }
}