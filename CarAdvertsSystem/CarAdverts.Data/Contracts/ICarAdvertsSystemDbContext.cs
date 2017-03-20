using CarAdverts.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CarAdverts.Data.Contracts
{
    public interface ICarAdvertsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Advert> Adverts { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<VehicleModel> VehicleModels { get; set; }

        IDbSet<File> Files { get; set; }

        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
