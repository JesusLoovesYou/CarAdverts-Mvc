using CarAdverts.Common.Constants;
using CarAdverts.Data.Contracts;
using CarAdverts.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class Advert : DeletableEntity, IAdvert
    {
        private ICollection<Picture> pictures;

        public Advert()
        {
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.AdvertTitleMinLength)]
        [MaxLength(ValidationConstants.AdvertTitleMaxLength)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int VehicleModelId { get; set; }

        [ForeignKey("VehicleModelId")]
        public virtual VehicleModel VehicleModel { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int DistanceCoverage { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        [MinLength(ValidationConstants.AdvertDescriptionMinLength)]
        [MaxLength(ValidationConstants.AdvertDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get
            {
                return this.pictures;
            }

            set
            {
                this.pictures = value;
            }
        }
    }
}
