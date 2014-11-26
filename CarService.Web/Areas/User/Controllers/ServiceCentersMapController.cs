namespace CarService.Web.Areas.User.Controllers
{   
    using System.Web.Mvc;
    using CarService.Data;

    public class ServiceCentersMapController : UserAreaController
    {
        public ServiceCentersMapController(ICarServiceData data)
            :base(data)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}