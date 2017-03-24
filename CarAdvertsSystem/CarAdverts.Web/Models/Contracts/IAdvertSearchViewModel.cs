namespace CarAdverts.Web.Models.Contracts
{
    public interface IAdvertSearchViewModel
    {
        int CategoryId { get; set; }
        int CityId { get; set; }
        int ManufacturerId { get; set; }
        int MaxDistanceCoverage { get; set; }
        int MaxPower { get; set; }
        decimal MaxPrice { get; set; }
        int MaxYear { get; set; }
        int MinDistanceCoverage { get; set; }
        int MinPower { get; set; }
        decimal MinPrice { get; set; }
        int MinYear { get; set; }
        int VehicleModelId { get; set; }
    }
}