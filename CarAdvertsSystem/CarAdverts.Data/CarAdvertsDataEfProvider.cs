using CarAdverts.Data.Contracts;
using System;
using System.Collections.Generic;
using CarAdverts.Models;
using CarAdverts.Data.Repositories.Base;
using CarAdverts.Data.Repositories.Contracts;
using CarAdverts.Models.Contracts;

namespace CarAdverts.Data
{
    public class CarAdvertsDataEfProvider : ICarAdvertsDataEfProvider
    {
        private readonly ICarAdvertsSystemDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CarAdvertsDataEfProvider(ICarAdvertsSystemDbContext context)
        {
            this.context = context;
        }

        public IDeletableEntityRepository<Advert> Adverts => this.GetDeletableEntityRepository<Advert>();
        
        public IEfRepository<Manufacturer> Manufacturers => this.GetRepository<Manufacturer>();

        public IEfRepository<VehicleModel> VehicleModels => this.GetRepository<VehicleModel>();

        public IEfRepository<Category> Categories => this.GetRepository<Category>();

        public IEfRepository<City> Cities => this.GetRepository<City>();

        public IEfRepository<Picture> Pictures => this.GetRepository<Picture>();

        public IEfRepository<User> Users => this.GetRepository<User>();

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
        private IEfRepository<T> GetRepository<T>()
            where T : class
        {
            //if (!this.repositories.ContainsKey(typeof(T)))
            //{
            //    var type = typeof(EfGenericRepository<T>);

            //    if (typeof(T).IsAssignableFrom(typeof(Test)))
            //    {
            //        type = typeof(TestRepository);
            //    }
            
            //    this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            //}

            return (IEfRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>()
           where T : class, IDbModel, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
