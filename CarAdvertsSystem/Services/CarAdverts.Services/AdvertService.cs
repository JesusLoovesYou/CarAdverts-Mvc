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

        public IQueryable<Advert> All()
        {
            var adverts = this.efProvider.Adverts.All();

            return adverts;
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

        public void Delete(Advert advert)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            this.efProvider.Adverts.Delete(advert);
            this.efProvider.SaveChanges();
        }

        public void Delete(int id)
        {
            this.efProvider.Adverts.Delete(id);
            this.efProvider.SaveChanges();
        }

        public void Update(Advert advert)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            this.efProvider.Adverts.Update(advert);
            this.efProvider.SaveChanges();
        }


        /// da go iztestvam
        public void CreateAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            if (uploadedFiles != null && uploadedFiles.Count() > 0)
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

        public IQueryable<Advert> Search(         //////////// da go iztestvam
                int vehicleModelId,
                int cityId,
                int minYear,
                int maxYear,
                decimal minPrice,
                decimal maxPrice,
                int minPower,
                int maxPower,
                int minDistanceCoverage,
                int maxDistanceCoverage)
        {
            var adverts = this.efProvider.Adverts
                .All();
            //.Where(a => a.VehicleModelId == model.VehicleModelId &&
            //            a.CityId == model.CityId &&
            //            a.Year >= model.MinYear && a.Year <= model.MaxPower &&
            //            a.Price >= model.MinPrice && a.Price <= model.MaxPrice &&
            //            a.Power >= model.MinPower && a.Power <= model.MaxPower &&
            //            a.DistanceCoverage >= model.MinDistanceCoverage &&
            //            a.DistanceCoverage <= model.MaxDistanceCoverage)

            return adverts;
        }
    }
}
