using System.Linq;

namespace CarAdverts.Data.Repositories.EfRepository.Contracts
{
    public interface IEfDeletableRepository<T> : IEfGenericRepository<T>
        where T : class
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
