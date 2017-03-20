using System.Collections.Generic;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertInputViewModel //: IMapFrom<CarAdverts.Models.Advert>
    {
        public string Title { get; set; }
        
        public int VehicleModelId { get; set; }
        
        public int Year { get; set; }
        
        public decimal Price { get; set; }
        
        public int Power { get; set; }
        
        public int DistanceCoverage { get; set; }
        
        public int CityId { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<FileViewModel> FilesToBeUploaded { get; set; }
    }
}