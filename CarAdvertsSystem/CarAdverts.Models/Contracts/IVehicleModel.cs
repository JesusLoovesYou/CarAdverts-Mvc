using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface IVehicleModel
    {
        ICollection<Advert> Adverts { get; set; }
        Category Category { get; set; }
        int CategoryId { get; set; }
        int Id { get; set; }
        Manufacturer Manufacturer { get; set; }
        int ManufacturerId { get; set; }
        string Name { get; set; }
    }
}