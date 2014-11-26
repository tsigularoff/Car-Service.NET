namespace CarService.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CarService.Data;
    using CarService.Web.Areas.User.Models;
       
    public class ServiceCentersMapController : UserAreaController
    {
        public ServiceCentersMapController(ICarServiceData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            var serviceCenters = this.data.CarServiceCenters
                .All()
                .Project()
                .To<CarServiceCenterMapViewModel>()
                .ToList();

            this.ConvertLocationString(serviceCenters);

            return View(serviceCenters);
        }

        private void ConvertLocationString(IEnumerable<CarServiceCenterMapViewModel> serviceCenters)
        {
            var separator = new char[] {';'};

            foreach (var item in serviceCenters)
            {
                var locationSplitted = item.Location.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                item.Lat = double.Parse(locationSplitted.First());
                item.Lng = double.Parse(locationSplitted.Last());
            }
        }
    }
}