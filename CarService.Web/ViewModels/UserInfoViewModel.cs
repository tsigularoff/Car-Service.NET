namespace CarService.Web.ViewModels
{
    using CarService.Web.Infrastucture.Mapping;

    using CarService.Models;
    
    public class UserInfoViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public int AddedServicesCount { get; set; }

        public int AddedServiceCentersCount { get; set; }
    }
}