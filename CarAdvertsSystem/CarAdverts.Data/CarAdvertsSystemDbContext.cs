using CarAdverts.Data.Contracts;
using CarAdverts.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CarAdverts.Data
{
    public class CarAdvertsSystemDbContext : IdentityDbContext<User>, ICarAdvertsSystemDbContext
    {
        public CarAdvertsSystemDbContext()
            : base("CarAdvertsSystemDb")
        {
        }
        
        public virtual IDbSet<Advert> Adverts { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<VehicleModel> VehicleModels { get; set; }

        public virtual IDbSet<File> Files { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static CarAdvertsSystemDbContext Create()
        {
            return new CarAdvertsSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
