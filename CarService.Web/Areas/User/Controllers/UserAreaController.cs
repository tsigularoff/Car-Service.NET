namespace CarService.Web.Areas.User.Controllers
{
    using CarService.Data;
    using System.Web.Mvc;

    [Authorize]
    public class UserAreaController : Controller
    {
        protected ICarServiceData data;

        
        public UserAreaController(ICarServiceData data)
        {
            this.data = data;
        }
    }
}