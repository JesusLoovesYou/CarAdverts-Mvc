using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface IManufacturer : IDbModel
    {
        ICollection<VehicleModel> Models { get; set; }
        string Name { get; set; }
    }
}