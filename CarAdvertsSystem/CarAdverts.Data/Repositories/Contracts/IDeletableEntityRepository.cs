using System.Linq;

namespace CarAdverts.Data.Repositories.Contracts
{
    public interface IDeletableEntityRepository<T> : IEfRepository<T>
        where T : class
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
