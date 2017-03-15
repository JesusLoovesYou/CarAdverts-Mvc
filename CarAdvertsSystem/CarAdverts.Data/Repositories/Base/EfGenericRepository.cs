using CarAdverts.Data.Contracts;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarAdverts.Data.Repositories.Contracts;
using Bytes2you.Validation;
using CarAdverts.Models.Contracts;

namespace CarAdverts.Data.Repositories.Base
{
    public class EfGenericRepository<T> : IEfRepository<T>
        where T : class, IDbModel
    {
        public EfGenericRepository(ICarAdvertsSystemDbContext context)
        {
            Guard.WhenArgument(context, nameof(ICarAdvertsSystemDbContext)).IsNull().Throw();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }


        protected IDbSet<T> DbSet { get; set; }

        public ICarAdvertsSystemDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return this.DbSet.FirstOrDefault(e => e.Id == id);
        }
        
        public void Add(T entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();

            this.DbSet.Add(entity);
        }

        public void Update(T entity)
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
        
        public void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }
        
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
