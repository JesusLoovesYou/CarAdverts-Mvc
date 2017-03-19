using System.Linq;

namespace CarAdverts.Data.Repositories.EfRepository.Contracts
{
    public interface IEfGenericRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        void Dispose();
    }
}
