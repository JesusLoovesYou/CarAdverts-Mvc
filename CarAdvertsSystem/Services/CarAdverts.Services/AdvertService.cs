using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using System.Collections.Generic;
using System.Web;
using Bytes2you.Validation;
using System.Linq;

namespace CarAdverts.Services
{
    public class AdvertService : IAdvertService
    {
        private IEfCarAdvertsDataProvider efProvider;

        public AdvertService(IEfCarAdvertsDataProvider efProvider)
        {
            Guard.WhenArgument(efProvider, nameof(efProvider)).IsNull().Throw();

            this.efProvider = efProvider;
        }

        public Advert GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var advert = this.efProvider.Adverts.GetById(id);
            return advert;
        }

        public void CreateAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            if (uploadedFiles.Count() > 0)
            {
                this.AddUploadedFilesToAdvert(advert, uploadedFiles);
            }
            
            this.efProvider.Adverts.Add(advert);
            this.efProvider.SaveChanges();
        }

        // I dont know how to test it.
        public void AddUploadedFilesToAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            if (uploadedFiles != null)
            {
                foreach (HttpPostedFileBase file in uploadedFiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var picture = new File
                        {
                            Name = System.IO.Path.GetFileName(file.FileName),
                            FileType = FileType.Photo,
                            ContentType = file.ContentType
                        };

                        using (var reader = new System.IO.BinaryReader(file.InputStream))
                        {
                            picture.Content = reader.ReadBytes(file.ContentLength);
                        }

                        advert.Pictures.Add(picture);
                    }
                }
            }
        }

        //public IQueryable<Advert> Search(
        //        int vehicleModelId,
        //        int cityId, 
        //        int minYear, int maxYear,
        //        decimal minPrice, decimal maxPrice,
        //        int minPower, int maxPower,
        //        int minDistanceCoverage, int maxDistanceCoverage)
        //{
        //    var adverts = this.efProvider.Adverts
        //        .All();
        //    //.Where(a => a.VehicleModelId == model.VehicleModelId &&
        //    //            a.CityId == model.CityId &&
        //    //            a.Year >= model.MinYear && a.Year <= model.MaxPower &&
        //    //            a.Price >= model.MinPrice && a.Price <= model.MaxPrice &&
        //    //            a.Power >= model.MinPower && a.Power <= model.MaxPower &&
        //    //            a.DistanceCoverage >= model.MinDistanceCoverage &&
        //    //            a.DistanceCoverage <= model.MaxDistanceCoverage)

        //    return adverts;
        //}

        //public IQueryable<Advert> SearchWithPaging(AdvertSearchViewModel searchModel, int page, int ItemsPerPage)
        //{
        //    var itemsToSkip = (page - 1) * ItemsPerPage;

        //    var adverts = this.efProvider.Adverts
        //        .All()
        //        //.Where(a => a.VehicleModelId == model.VehicleModelId &&
        //        //            a.CityId == model.CityId &&
        //        //            a.Year >= model.MinYear && a.Year <= model.MaxPower &&
        //        //            a.Price >= model.MinPrice && a.Price <= model.MaxPrice &&
        //        //            a.Power >= model.MinPower && a.Power <= model.MaxPower &&
        //        //            a.DistanceCoverage >= model.MinDistanceCoverage &&
        //        //            a.DistanceCoverage <= model.MaxDistanceCoverage)
        //        .OrderBy(a => a.CreatedOn)
        //        .ThenBy(a => a.Id)
        //        .Skip(itemsToSkip)
        //        .Take(ItemsPerPage);

        //    return adverts;
        //}
    }
}
