using CarAdverts.Models;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models
{
    public class ManufacturerViewModel : IMapFrom<Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}