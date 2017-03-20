using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;

namespace CarAdverts.Data.Providers.EfProvider
{
    public interface IEfCarAdvertsDataProvider
    {
        IEfDeletableRepository<Advert> Adverts { get; }

        IEfGenericRepository<Manufacturer> Manufacturers { get; }

        IEfGenericRepository<VehicleModel> VehicleModels { get; }

        IEfGenericRepository<Category> Categories { get; }

        IEfGenericRepository<City> Cities { get; }

        IEfGenericRepository<File> Files { get; }

        IEfGenericRepository<User> Users { get; }

        ICarAdvertsSystemDbContext Context { get; }

        int SaveChanges();
    }
}
