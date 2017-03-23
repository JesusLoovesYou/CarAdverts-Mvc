using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;
using CarAdverts.Services.Contracts;
using PagedList;
using Bytes2you.Validation;

namespace CarAdverts.Web.Controllers
{
    public class AdvertController : Controller
    {
        private const int ItemsPerPage = 1;

        private IEfCarAdvertsDataProvider provider;

        private IAdvertService advertService;

        public AdvertController(IEfCarAdvertsDataProvider provider,
            IAdvertService advertService)
        {
            Guard.WhenArgument(provider, nameof(provider)).IsNull().Throw();
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();

            this.provider = provider;
            this.advertService = advertService;
        }

        [HttpGet]
        public ActionResult Index(AdvertSearchViewModel model, int page = 1)
        {
            //var itemsToSkip = (page - 1) * ItemsPerPage;

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
                .ProjectTo<AdvertViewModel>()
                .ToList();

            //var allItemsCount = adverts.Count();
            //var totalpages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            //var viewModel = new PageableAdvertsListViewModel()
            //{
            //    CurrentPage = page,
            //    TotalPages = totalpages,
            //    Adverts = adverts
            //};
            
            return View(adverts.ToPagedList(page, 1));
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

            try
            {
                this.advertService.CreateAdvert(advert, uploadedFiles);
            }
            catch (Exception)
            {

                this.TempData["Notification"] = "Exeption.";
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

            var advert = this.advertService.GetById(id);

            if (advert == null)
            {
                return HttpNotFound();
            }

            var advertView = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            return View(advertView);
        }
    }
}