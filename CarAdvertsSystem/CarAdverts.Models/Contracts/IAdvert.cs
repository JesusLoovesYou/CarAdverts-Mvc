using System.Collections.Generic;

namespace CarAdverts.Models.Contracts
{
    public interface IAdvert
    {
        City City { get; set; }
        int CityId { get; set; }
        string Description { get; set; }
        int DistanceCoverage { get; set; }
        int Id { get; set; }
        bool IsDeleted { get; set; }
        int Power { get; set; }
        decimal Price { get; set; }
        string Title { get; set; }
        User User { get; set; }
        string UserId { get; set; }
        VehicleModel VehicleModel { get; set; }
        int VehicleModelId { get; set; }
        int Year { get; set; }
        ICollection<Picture> Pictures { get; set; }
    }
}