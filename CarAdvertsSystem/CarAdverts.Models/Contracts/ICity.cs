using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface ICity
    {
        ICollection<Advert> Adverts { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}
