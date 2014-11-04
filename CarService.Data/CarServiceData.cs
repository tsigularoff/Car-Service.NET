namespace CarService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using CarService.Data.Repositories;
    using CarService.Models;

    public class CarServiceData : ICarServiceData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;
        private CarServiceDbContext ctx;

        public CarServiceData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }       

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
