using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CarAdverts.Web.Models;

namespace CarAdverts.Web.Areas.User.Models
{
    [Authorize]
    public class AdvertInputViewModel
    {
        [DataType(DataType.Text)]
        [AllowHtml]
        public string Title { get; set; }
        
        [Display(Name = "Model")]
        public int VehicleModelId { get; set; }
        
        public int Year { get; set; }
        
        public decimal Price { get; set; }
        
        public int Power { get; set; }
        
        public int DistanceCoverage { get; set; }
        
        [Display(Name = "City")]
        public int CityId { get; set; }
        
        [UIHint("MultilineText")]
        [AllowHtml]
        public string Description { get; set; }

        public IEnumerable<FileViewModel> FilesToBeUploaded { get; set; }
    }
}