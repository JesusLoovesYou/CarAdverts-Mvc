using System.ComponentModel.DataAnnotations;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertInputViewModel //: IMapFrom<CarAdverts.Models.Advert>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int DistanceCoverage { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}