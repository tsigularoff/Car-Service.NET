namespace CarService.Data
{
    using CarService.Data.Repositories;   
    using CarService.Models;

    public interface ICarServiceData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<CarServiceCenter> CarServiceCenters { get; }

        IRepository<CarModel> CarModels { get; }

        IRepository<CarService> CarServices { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        int SaveChanges();
    }
}
