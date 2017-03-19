using System.Data.Entity.Migrations;
using System.Linq;
using CarAdverts.Models;

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
            //if (context.Roles.Count() == 0)
            {
                //context.Roles.Add(new IdentityRole("admin"));
                //context.Roles.Add(new IdentityRole("user"));
                //context.SaveChanges();


                //var adminRole = new IdentityUserRole();
                //adminRole.RoleId = context.Roles.FirstOrDefault(r => r.Name == "admin").Id;
                //context.SaveChanges();

                //var userRole = new IdentityUserRole();
                //userRole.RoleId = context.Roles.FirstOrDefault(r => r.Name == "user").Id;
                //context.SaveChanges();

                //var adminUser = context.Users.First(u => u.Email == "admin@abv.bg");
                //var regularUser = context.Users.First(x => x.Email == "chuk@.abv.bg");

                //if (adminUser != null && regularUser != null)
                {
                    //regularUser.Roles.Add(userRole);
                    //context.SaveChanges();
                    //adminUser.Roles.Clear();
                    //adminUser.Roles.Add(adminRole);
                    //context.SaveChanges();
                }

                ///////////////////////////////////////////////////////

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

                //if (!context.Adverts.Any())
                //{
                //    context.Adverts.AddOrUpdate(a => a.Id,
                //        new Advert()
                //        {
                //            Title = "adv1",
                //            CityId = 1,
                //            VehicleModelId = 1,
                //            DistanceCoverage = 500,
                //            Price = 100,
                //            Power = 100,
                //            Description = "neznam iide"
                            
                //        });
                //}
            }
        }
    }
}
