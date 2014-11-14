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

    public sealed class Configuration : DbMigrationsConfiguration<CarServiceDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarServiceDbContext context)
        {
            this.SeedUsers(context);
            this.SeedCarModels(context);

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

            var userAdmin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            var resultAdmin = userManager.Create(userAdmin, "123456");

            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, "Admin");
            }

            context.SaveChanges();
        }
    }
}
