using CarAdverts.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdverts.Common.Constants;

namespace CarAdverts.Models
{
    public class File : IFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FileNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FileContentTypeMaxLength)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public FileType FileType { get; set; }

        public int AdvertId { get; set; }

        [ForeignKey("AdvertId")]
        public virtual Advert Advert { get; set; }
    }
}
