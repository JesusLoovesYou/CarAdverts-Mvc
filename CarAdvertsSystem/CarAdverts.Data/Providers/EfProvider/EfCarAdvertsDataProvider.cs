using System;
using System.Collections.Generic;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Models.Contracts;

namespace CarAdverts.Data.Providers.EfProvider
{
    public class EfCarAdvertsDataProvider : IEfCarAdvertsDataProvider
    {
        private readonly ICarAdvertsSystemDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public EfCarAdvertsDataProvider(ICarAdvertsSystemDbContext context)
        {
            this.context = context;
        }

        public IEfDeletableRepository<Advert> Adverts => this.GetDeletableEntityRepository<Advert>();
        
        public IEfGenericRepository<Manufacturer> Manufacturers => this.GetRepository<Manufacturer>();

        public IEfGenericRepository<VehicleModel> VehicleModels => this.GetRepository<VehicleModel>();

        public IEfGenericRepository<Category> Categories => this.GetRepository<Category>();

        public IEfGenericRepository<City> Cities => this.GetRepository<City>();

        public IEfGenericRepository<File> Files => this.GetRepository<File>();

        public IEfGenericRepository<User> Users => this.GetRepository<User>();

        public ICarAdvertsSystemDbContext Context => this.context;
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
            }
        }

        // I dont like this method.
        private IEfGenericRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);
                this.repositories.Add(typeof(T), (Activator.CreateInstance(type, this.context)));
            }

            return (IEfGenericRepository<T>)this.repositories[typeof(T)];
        }

        private IEfDeletableRepository<T> GetDeletableEntityRepository<T>()
           where T : class, IDbModel, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfDeletableRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IEfDeletableRepository<T>)this.repositories[typeof(T)];
        }
    }
}
