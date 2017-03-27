using System.Linq;
using CarAdverts.Models;

namespace CarAdverts.Services.Contracts
{
    public interface ICityService
    {
        IQueryable<City> All();
    }
}