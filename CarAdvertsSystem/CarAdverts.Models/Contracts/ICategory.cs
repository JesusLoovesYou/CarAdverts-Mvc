using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface ICategory : IDbModel
    {
        string Name { get; set; }

        ICollection<VehicleModel> VethicleModels { get; set; }
    }
}