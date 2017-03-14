namespace CarAdverts.Models.Contracts
{
    public interface IPicture
    {
        Advert Advert { get; set; }
        int AdvertId { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}