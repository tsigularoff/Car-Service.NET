namespace CarService.Web.Controllers
{    
    using System.Web.Mvc;
    using CarService.Data;

    public class PublicController : BaseController
    {
        public PublicController(ICarServiceData data)
            :base(data)
        {
        }

        public ActionResult ServiceCenters()
        {
            return View();
        }
    }
}