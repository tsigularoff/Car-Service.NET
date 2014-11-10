namespace CarService.Web.Controllers
{    
    using System.Web.Mvc;
    using CarService.Data;

    
    public class BaseController : Controller
    {
        protected ICarServiceData data;

        public BaseController(ICarServiceData data)
        {
            this.data = data;
        }        
    }
}