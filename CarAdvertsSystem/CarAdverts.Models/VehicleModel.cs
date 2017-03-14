using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class VehicleModel : IVehicleModel
    {
        private ICollection<Advert> adverts;

        public VehicleModel()
        {
            this.adverts = new HashSet<Advert>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.VechicleNameMinLength)]
        [MaxLength(ValidationConstants.VechicleNameMaxLength)]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Advert> Adverts
        {
            get
            {
                return this.adverts;
            }

            set
            {
                this.adverts = value;
            }
        }
    }
}
