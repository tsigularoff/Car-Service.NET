namespace CarService.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Hosting;

    using CarService.Data.SeedData;
    using CarService.Models;

    public sealed class Configuration : DbMigrationsConfiguration<CarServiceDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarServiceDbContext context)
        {
            var rootPath = HostingEnvironment.MapPath("~/");
            var seedDataPath = rootPath + @"../CarService.Data/SeedData/CarModels.txt";

            if (!context.Manufacturers.Any())
            {

                var manufacturers = CarModelsReader.GetCarDataFromFile(seedDataPath);

                context.Manufacturers.AddOrUpdate(manufacturers.ToArray());
            }
            
        }
    }
}
