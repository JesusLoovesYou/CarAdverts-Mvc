using System.Collections.Generic;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertSearchViewModel
    {
        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public int VehicleModelId { get; set; }

        public int CityId { get; set; }

        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public int MinPower { get; set; }
        public int MaxPower { get; set; }

        public int MinDistanceCoverage { get; set; }
        public int MaxDistanceCoverage { get; set; }

        //public IEnumerable<CategoryViewModel> Categories { get; set; }
       
        //public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }
       
        //public IEnumerable<VehicleModelViewModel> VehicleModels { get; set; }
        
        //public IEnumerable<CityViewModel> Cities { get; set; }
    }
}