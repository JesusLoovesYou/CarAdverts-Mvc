using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;

namespace CarAdverts.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private IEfCarAdvertsDataProvider efProvider;

        public VehicleModelService(IEfCarAdvertsDataProvider efProvider)
        {
            Guard.WhenArgument(efProvider, nameof(efProvider)).IsNull().Throw();

            this.efProvider = efProvider;
        }

        public IQueryable<VehicleModel> All()
        {
            var models = this.efProvider.VehicleModels.All();

            return models;
        }
    }
}
