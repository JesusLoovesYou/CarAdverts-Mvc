using System.Collections.Generic;
using System.Web;
using CarAdverts.Models;
using System.Linq;

namespace CarAdverts.Services.Contracts
{
    public interface IAdvertService
    {
        void AddUploadedFilesToAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles);
        void CreateAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles);

        Advert GetById(int? id);

        void Delete(Advert advert);

        void Delete(int id);

        void Update(Advert advert);

        IQueryable<Advert> All();

        IQueryable<Advert> Search(
            int vehicleModelId,
            int cityId,
            int minYear,
            int maxYear,
            decimal minPrice,
            decimal maxPrice,
            int minPower,
            int maxPower,
            int minDistanceCoverage,
            int maxDistanceCoverage);
    }
}