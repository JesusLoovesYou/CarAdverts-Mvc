using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class Picture : IPicture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.PictureNameMinLength)]
        [MaxLength(ValidationConstants.PictureNameMaxLength)]
        public string Name { get; set; }

        public int AdvertId { get; set; }

        [ForeignKey("AdvertId")]
        public virtual Advert Advert { get; set; }
    }
}
