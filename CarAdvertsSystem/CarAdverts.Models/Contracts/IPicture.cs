namespace CarAdverts.Models.Contracts
{
    public interface IPicture : IDbModel
    {
        string Name { get; set; }

        Advert Advert { get; set; }

        int AdvertId { get; set; }
    }
}