using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class Category : ICategory
    {
        private ICollection<VehicleModel> vethicleModel;

        public Category()
        {
            this.vethicleModel = new HashSet<VehicleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CategoryNameMinLength)]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> VethicleModels
        {
            get
            {
                return this.vethicleModel;
            }

            set
            {
                this.vethicleModel = value;
            }
        }
    }
}
