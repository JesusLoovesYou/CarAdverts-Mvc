namespace CarAdverts.Models.Contracts
{
    public interface IFile : IDbModel
    {
        string Name { get; set; }

        string ContentType { get; set; }

        byte[] Content { get; set; }

        FileType FileType { get; set; }

        Advert Advert { get; set; }

        int AdvertId { get; set; }
    }
}