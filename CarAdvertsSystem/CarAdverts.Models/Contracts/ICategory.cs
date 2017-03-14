using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }
        ICollection<VehicleModel> VethicleModels { get; set; }
        string Name { get; set; }
    }
}