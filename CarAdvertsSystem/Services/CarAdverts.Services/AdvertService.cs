using System;
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

        /// <summary>
        /// Search adverts from database.
        /// </summary>
        /// <param name="vehicleModelId"></param>
        /// <param name="cityId"></param>
        /// <param name="minYear"></param>
        /// <param name="maxYear"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="minPower"></param>
        /// <param name="maxPower"></param>
        /// <param name="minDistanceCoverage"></param>
        /// <param name="maxDistanceCoverage"></param>
        /// <returns>IQuearable from Adverts.</Adverts></returns>
        public IQueryable<Advert> Search(
                int? vehicleModelId,
                int? cityId,
                int? minYear,
                int? maxYear,
                decimal? minPrice,
                decimal? maxPrice,
                int? minPower,
                int? maxPower,
                int? minDistanceCoverage,
                int? maxDistanceCoverage)
        {
            ValidateIntegerMinAndMaxNumbers(ref minYear, ref maxYear);

            ValidateDecimalMinAndMaxNumbers(ref minPrice, ref maxPrice);

            ValidateIntegerMinAndMaxNumbers(ref minPower, ref maxPower);

            ValidateIntegerMinAndMaxNumbers(ref minDistanceCoverage, ref maxDistanceCoverage);

            var adverts = this.efProvider.Adverts
                .All()
                .Where(a => a.VehicleModelId == (vehicleModelId ?? a.VehicleModelId) &&
                       a.CityId == (cityId ?? a.CityId) &&
                       a.Year >= (minYear ?? a.Year) &&
                       a.Year <= (maxYear ?? a.Year) &&
                       a.Price >= (minPrice ?? a.Price) &&
                       a.Price <= (maxPrice ?? a.Price) &&
                       a.Power >= (minPower ?? a.Power) &&
                       a.Power <= (maxPower ?? a.Power) &&
                       a.DistanceCoverage >= (minDistanceCoverage ?? a.DistanceCoverage) &&
                       a.DistanceCoverage <= (maxDistanceCoverage ?? a.DistanceCoverage));

            return adverts;
        }
        
        /// <summary>
        /// Swap two decimal nulable numbers.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void ValidateDecimalMinAndMaxNumbers(ref decimal? min, ref decimal? max)
        {
            if (min != null && max != null && min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
        }

        /// <summary>
        /// Swap two integer nulable numbers.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void ValidateIntegerMinAndMaxNumbers(ref int? min, ref int? max)
        {
            if (min != null && max != null && min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
        }
    }
}
