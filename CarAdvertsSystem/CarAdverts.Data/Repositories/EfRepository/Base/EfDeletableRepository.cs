using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Contracts;

namespace CarAdverts.Data.Repositories.EfRepository.Base
{
    public class EfDeletableRepository<T> : EfGenericRepository<T>, IEfDeletableRepository<T>
        where T : class, IDeletableEntity
    {
        public EfDeletableRepository(ICarAdvertsSystemDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }
    }
}
