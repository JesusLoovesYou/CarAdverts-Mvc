using System.Linq;
using CarAdverts.Models;

namespace CarAdverts.Services.Contracts
{
    public interface IVehicleModelService
    {
        IQueryable<VehicleModel> All();
    }
}