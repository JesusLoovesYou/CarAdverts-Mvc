using CarAdverts.Models;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models
{
    public class VehicleModelViewModel : IMapFrom<VehicleModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}