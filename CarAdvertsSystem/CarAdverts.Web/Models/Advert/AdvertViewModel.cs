using System;
using System.Collections.Generic;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertViewModel : IMapFrom<CarAdverts.Models.Advert>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int VehicleModelId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Power { get; set; }

        public string DistanceCoverage { get; set; }

        public string CityId { get; set; }

        public string Description { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public string Url => $"/adverts/{this.Id}/{this.Title.ToLower().Replace(" ", "-")}";

        public IEnumerable<FileViewModel> Pictures { get; set; }
    }
}