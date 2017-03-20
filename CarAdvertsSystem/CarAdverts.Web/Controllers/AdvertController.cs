using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;
using File = CarAdverts.Models.File;

namespace CarAdverts.Web.Controllers
{
    public class AdvertController : Controller
    {
        private const int ItemsPerPage = 1;

        private IEfCarAdvertsDataProvider provider;

        public AdvertController(IEfCarAdvertsDataProvider provider,
            IEfDeletableRepository<CarAdverts.Models.Advert> testadvert)
        {
            this.provider = provider;
        }

        [HttpGet]
        public ActionResult Index(AdvertSearchViewModel model, int id = 1)
        {
            var page = id;
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var adverts = this.provider.Adverts
                .All()
                //.Where(a => a.VehicleModelId == model.VehicleModelId &&
                //            a.CityId == model.CityId &&
                //            a.Year >= model.MinYear && a.Year <= model.MaxPower &&
                //            a.Price >= model.MinPrice && a.Price <= model.MaxPrice &&
                //            a.Power >= model.MinPower && a.Power <= model.MaxPower &&
                //            a.DistanceCoverage >= model.MinDistanceCoverage &&
                //            a.DistanceCoverage <= model.MaxDistanceCoverage)
                .OrderBy(a => a.CreatedOn)
                .ThenBy(a => a.Id)
                //.Skip(itemsToSkip)
                //.Take(ItemsPerPage)
                .ProjectTo<AdvertViewModel>()
                .ToList();

            var allItemsCount = adverts.Count();
            var totalpages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var viewModel = new PageableAdvertsListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalpages,
                Adverts = adverts
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(AdvertInputViewModel model, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            
            var advert = new Advert()
            {
                Title = model.Title,
                VehicleModelId = model.VehicleModelId,
                UserId = this.User.Identity.GetUserId(),
                Year = model.Year,
                Price = model.Price,
                Power = model.Power,
                DistanceCoverage = model.DistanceCoverage,
                CityId = model.CityId,
                Description = model.Description,
                CreatedOn = DateTime.Now
            };

            // File upload
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

            this.provider.Adverts.Add(advert);
            try
            {
                this.provider.SaveChanges();
            }
            catch (Exception ex)
            {
                // Triabva da prihvana greshkite
                this.TempData["Notification"] = "Error.";
            }
            

            this.TempData["Notification"] = "Succesfull advert creation.";

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var advert = this.provider.Adverts.GetById(id);

            if (advert == null)
            {
                return HttpNotFound();
            }

            var advertView = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            return View(advertView);
        }
        
    }
}