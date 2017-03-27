using System.Linq;
using Bytes2you.Validation;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;

namespace CarAdverts.Services
{
    public class CityService : ICityService
    {
        private IEfCarAdvertsDataProvider efProvider;

        public CityService(IEfCarAdvertsDataProvider efProvider)
        {
            Guard.WhenArgument(efProvider, nameof(efProvider)).IsNull().Throw();

            this.efProvider = efProvider;
        }

        public IQueryable<City> All()
        {
            var cities = this.efProvider.Cities.All();

            return cities;
        }
    }
}
