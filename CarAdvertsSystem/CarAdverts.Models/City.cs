using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class City : ICity
    {
        private ICollection<Advert> adverts;

        public City()
        {
            this.adverts = new HashSet<Advert>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.CityNameMinLength)]
        [MaxLength(ValidationConstants.CityNameMaxLength)]
        public string Name { get; set; }

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
