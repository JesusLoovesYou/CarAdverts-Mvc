using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class Manufacturer : IManufacturer
    {
        private ICollection<VehicleModel> models;

        public Manufacturer()
        {
            this.models = new HashSet<VehicleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.ManufacturerNameMinLength)]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> Models
        {
            get
            {
                return this.models;
            }

            set
            {
                this.models = value;
            }
        }
    }
}
