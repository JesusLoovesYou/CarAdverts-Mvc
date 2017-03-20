using CarAdverts.Models;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models
{
    public class FileViewModel : IMapFrom<File>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

    }
}