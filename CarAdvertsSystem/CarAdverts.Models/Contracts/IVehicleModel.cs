using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface IVehicleModel : IDbModel
    {
        string Name { get; set; }

        ICollection<Advert> Adverts { get; set; }

        int CategoryId { get; set; }
        Category Category { get; set; }

        int ManufacturerId { get; set; }
        Manufacturer Manufacturer { get; set; }
    }
}