using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Bytes2you.Validation;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Contracts;

namespace CarAdverts.Data.Repositories.EfRepository.Base
{
    public class EfGenericRepository<T> : IEfGenericRepository<T> where T : class
    {
        public EfGenericRepository(ICarAdvertsSystemDbContext context)
        {
            Guard.WhenArgument(context, nameof(ICarAdvertsSystemDbContext)).IsNull().Throw();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        // to do mocked class and this properties protected
        public IDbSet<T> DbSet { get; set; }

        public ICarAdvertsSystemDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            var result = this.DbSet.AsQueryable();
            return result;
        }

        public virtual T GetById(int? id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();

            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();

            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
