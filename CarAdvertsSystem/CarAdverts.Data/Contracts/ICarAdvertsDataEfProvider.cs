using CarAdverts.Data.Repositories.Contracts;
using CarAdverts.Models;

namespace CarAdverts.Data.Contracts
{
    public interface ICarAdvertsDataEfProvider
    {
        IDeletableEntityRepository<Advert> Adverts { get; }

        IEfRepository<Manufacturer> Manufacturers { get; }

        IEfRepository<VehicleModel> VehicleModels { get; }

        IEfRepository<Category> Categories { get; }

        IEfRepository<City> Cities { get; }

        IEfRepository<Picture> Pictures { get; }

        IEfRepository<User> Users { get; }

        ICarAdvertsSystemDbContext Context { get; }

        int SaveChanges();
    }
}
