using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface ICity : IDbModel
    {
        string Name { get; set; }

        ICollection<Advert> Adverts { get; set; }
    }
}
