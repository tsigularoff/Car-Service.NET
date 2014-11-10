namespace CarService.Data
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using CarService.Models;
    using CarService.Data.Migrations;    

    public class CarServiceDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarServiceDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarServiceDbContext, Configuration>());  
        }

        public static CarServiceDbContext Create()
        {
            return new CarServiceDbContext();
        }

        public IDbSet<CarService> CarServices { get; set; }

        public IDbSet<CarServiceCenter> CarServiceCenters { get; set; }

        public IDbSet<CarModel> CarModles { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }       
    }
}
