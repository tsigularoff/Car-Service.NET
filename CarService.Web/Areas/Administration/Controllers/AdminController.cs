namespace CarService.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using CarService.Web.Controllers;
    using CarService.Data;

    //[Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {        
        public AdminController(ICarServiceData data)
            :base(data)
        {
        }
    }
}