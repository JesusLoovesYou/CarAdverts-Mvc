using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
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

        public int DistanceCoverage { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public string Description { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        
        public string UserId { get; set; }

        public string Url => $"/adverts/{this.Id}/{this.Title.ToLower().Replace(" ", "-")}";

        public int? FirstPictureId
        {
            get
            {
                if (this.Pictures == null || this.Pictures.ToList().Count == 0)
                {
                    return null;
                }

                return this.Pictures.First().Id;
            }
        }

        public IEnumerable<FileViewModel> Pictures { get; set; }
    }
}