using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.Contracts;
using CarAdverts.Models.Contracts;
using System;
using System.Linq;

namespace CarAdverts.Data.Repositories.Base
{
    public class DeletableEntityRepository<T> : EfGenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDbModel, IDeletableEntity, new()
    {
        public DeletableEntityRepository(ICarAdvertsSystemDbContext context)
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

            this.Update(entity);
        }

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }
    }
}
