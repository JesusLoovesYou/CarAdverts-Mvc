using System.Data.Entity.Migrations;
using System.Linq;
using CarAdverts.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarAdverts.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarAdvertsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarAdvertsSystemDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                this.AddUserAndRole(context);
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(c => c.Id,
                    new Category { Id = 0, Name = "Bus" },
                    new Category { Id = 1, Name = "Caravan" },
                    new Category { Id = 2, Name = "Car" },
                    new Category { Id = 3, Name = "Motorbike" },
                    new Category { Id = 5, Name = "SUV" }
                );
            }

            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.AddOrUpdate(m => m.Id,
                    new Manufacturer { Id = 1, Name = "Audi" },
                    new Manufacturer { Id = 2, Name = "Peugeot" },
                    new Manufacturer { Id = 3, Name = "KIA" },
                    new Manufacturer { Id = 4, Name = "Dacia" },
                    new Manufacturer { Id = 5, Name = "Lamborghini" },
                    new Manufacturer { Id = 6, Name = "BMV" }
                );
            }

            if (!context.VehicleModels.Any())
            {
                context.VehicleModels.AddOrUpdate(v => v.Id,
                    new VehicleModel { Id = 1, Name = "A4", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 2, Name = "A6", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 3, Name = "A8", CategoryId = 2, ManufacturerId = 1 },
                    new VehicleModel { Id = 4, Name = "100", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 5, Name = "S8", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 6, Name = "XS", CategoryId = 2, ManufacturerId = 2 },
                    new VehicleModel { Id = 7, Name = "TT", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 8, Name = "Uou", CategoryId = 2, ManufacturerId = 3 },
                    new VehicleModel { Id = 9, Name = "Test", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 10, Name = "80", CategoryId = 1, ManufacturerId = 1 }
                );
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddOrUpdate(c => c.Id,
                    new City { Id = 1, Name = "Sofia" },
                    new City { Id = 2, Name = "Dupnica" },
                    new City { Id = 3, Name = "Tyrnovo" },
                    new City { Id = 4, Name = "Haskovo" }
                );
            }
        }

        private bool AddUserAndRole(CarAdvertsSystemDbContext context)
        {
            var user = new User()
            {
                UserName = "admin@abv.bg",
            };

            var roleMenager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityResult identityResult = roleMenager.Create(new IdentityRole("Admin"));
            var userManager = new UserManager<User>(new UserStore<User>(context));
            identityResult = userManager.Create(user, "123456");
            if (identityResult.Succeeded == false)
            {
                return identityResult.Succeeded;
            }

            identityResult = userManager.AddToRole(user.Id, "Admin");
            return identityResult.Succeeded;
        }

    }
}
