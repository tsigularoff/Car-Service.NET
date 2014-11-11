﻿namespace CarService.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using CarService.Data;
    using CarService.Web.Models;

    using AutoMapper.QueryableExtensions;
    
    public class HomeController : BaseController
    {
        private const int ServiceCentersCount = 3;
        public HomeController(ICarServiceData data)
            :base(data)
        {
        }

        
        public ActionResult Index()
        {
            var serviceCentersCount = this.data.CarServiceCenters.All().Count();
            var regUsersCount = this.data.Users.All().Count();
            var carServiceCount = this.data.CarServices.All().Count();
            var manufaturersCount = this.data.Manufacturers.All().Count();
            var carModelsCount = this.data.CarModels.All().Count();                                           
                                                

            var homeViewInfo = new HomeViewModel
            {
                ServiceCentersCount = serviceCentersCount,
                RegisterUsersCount = regUsersCount,
                CarServicesCount = carServiceCount,
                CarModelsCount = carModelsCount,
                ManufacturersCount = manufaturersCount
            };

            return View(homeViewInfo);
        }        

        public ActionResult Contact()
        {           
            return View();
        }

        [OutputCache(Duration = 200, VaryByParam = "none")]       
        [ChildActionOnly]
        public ActionResult LastServiceCenters()
        {
            var lastCarServiceCenters = this.data.CarServiceCenters
               .All()
               .OrderByDescending(x => x.CreatedOn)
               .Project().To<ServiceCenterViewModel>()
               .Take(ServiceCentersCount);               

            return PartialView("_LastServiceCenters", lastCarServiceCenters);
        }

    }
}