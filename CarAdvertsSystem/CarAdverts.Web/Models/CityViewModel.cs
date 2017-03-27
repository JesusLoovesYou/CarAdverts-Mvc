using CarAdverts.Models;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models
{
    public class CityViewModel : IMapFrom<City>
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}