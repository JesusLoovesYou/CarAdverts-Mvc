using System.ComponentModel.DataAnnotations;
using CarAdverts.Web.Models.Contracts;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertSearchViewModel //: IAdvertSearchViewModel
    {
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Manufacturer")]
        public int? ManufacturerId { get; set; }

        [Display(Name = "Model")]
        public int? VehicleModelId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int? MinPower { get; set; }
        public int? MaxPower { get; set; }

        [Display(Name = "MinDistance")]
        public int? MinDistanceCoverage { get; set; }
        [Display(Name = "MaxDistance")]
        public int? MaxDistanceCoverage { get; set; }
    }
}