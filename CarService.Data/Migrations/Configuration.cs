namespace CarService.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Hosting;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    using CarService.Data.SeedData;
    using CarService.Models;
    using CarService.Data.SeedData;

    public sealed class Configuration : DbMigrationsConfiguration<CarServiceDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarServiceDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);    
            }

            if (!context.CarModles.Any())
            {
                this.SeedCarModels(context);    
            }

            if (!context.CarServiceCenters.Any())
            {
                this.SeedServiceCenters(context);    
            }
        }

        private void SeedCarModels(CarServiceDbContext context)
        {
            var rootPath = HostingEnvironment.MapPath("~/");
            var seedDataPath = rootPath + @"../CarService.Data/SeedData/CarModels.txt";

            if (!context.Manufacturers.Any())
            {

                var manufacturers = CarModelsReader.GetCarDataFromFile(seedDataPath);

                context.Manufacturers.AddOrUpdate(manufacturers.ToArray());
            }
        }

        private void SeedUsers(CarServiceDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("Admin"));

            var sampleUser = new ApplicationUser
            {
                UserName = "pesho@pesho.com",
                Email = "pesho@pesho.com"
            };

            var userAdmin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            var resultAdmin = userManager.Create(userAdmin, "123456");
            var resultUser = userManager.Create(sampleUser, "123456");

            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, "Admin");                
            }

            context.SaveChanges();
        }

        private void SeedServiceCenters(CarServiceDbContext context)
        {
            var rootPath = HostingEnvironment.MapPath("~/");
            var serviceCentersPath = rootPath + @"../CarService.Data/SeedData/CarServiceCenters.xml";
            var reader = new XMLGasStationReader();

            var serviceCenters = reader.GetServiceCenters(serviceCentersPath);

            context.CarServiceCenters.AddOrUpdate(serviceCenters.ToArray());
            context.SaveChanges();
        }
    }
}
