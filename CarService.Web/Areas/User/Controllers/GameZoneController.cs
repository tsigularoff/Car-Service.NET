namespace CarService.Web.Areas.User.Controllers
{   
    using System.Web.Mvc;
    using CarService.Data;

    public class GameZoneController : UserAreaController
    {
        public GameZoneController(ICarServiceData data)
            :base(data)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}