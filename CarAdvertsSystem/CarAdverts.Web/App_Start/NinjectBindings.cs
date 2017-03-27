using System.Data.Entity;
using CarAdverts.Common.Generator;
using CarAdverts.Data;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using Ninject.Modules;
using CarAdverts.Services.Contracts;
using CarAdverts.Services;
using Ninject.Web.Common;

namespace CarAdverts.Web
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<CarAdvertsSystemDbContext>();
            this.Bind<ICarAdvertsSystemDbContext>().To<CarAdvertsSystemDbContext>();
            this.Bind<IEfCarAdvertsDataProvider>().To<EfCarAdvertsDataProvider>();

            this.Bind(typeof(IEfGenericRepository<>)).To(typeof(EfGenericRepository<>));
            this.Bind(typeof(IEfDeletableRepository<>)).To(typeof(EfDeletableRepository<>));

            this.Bind<IAdvertService>().To<AdvertService>();
            this.Bind<IFileService>().To<FileService>();
            this.Bind<IVehicleModelService>().To<VehicleModelService>();
            this.Bind<ICityService>().To<CityService>();

            this.Bind<IGenerator>().To<Generator>();
        }
    }
}