using CarAdverts.Common.Constants;
using CarAdverts.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdverts.Models
{
    public class File : IFile
    {
        [Key]
        public int Id { get; set; }

        //[StringLength(255)]
        public string Name { get; set; }

        //[StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public int AdvertId { get; set; }

        [ForeignKey("AdvertId")]
        public virtual Advert Advert { get; set; }
    }
}
