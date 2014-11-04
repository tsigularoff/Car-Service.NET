namespace CarService.Data
{
    using CarService.Data.Repositories;   
    using CarService.Models;

    public interface ICarServiceData
    {
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
