using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
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
        
        private readonly IAdvertService advertService;

        public AdvertController(IAdvertService advertService)
        { 
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();
            
            this.advertService = advertService;
        }

        [HttpGet]
        public ActionResult Index(AdvertSearchViewModel model, int page = 1)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData["Notification"] = "Exeption.";

                return RedirectToAction("Index", "Home");
            }
            
            try
            {
                 var adverts = advertService.Search(
                    model.VehicleModelId,
                    model.CityId,
                    model.MinYear,
                    model.MaxYear,
                    model.MinPrice,
                    model.MaxPrice,
                    model.MinPower,
                    model.MaxPower,
                    model.MinDistanceCoverage,
                    model.MaxDistanceCoverage)
                .OrderBy(a => a.CreatedOn)
                .ThenBy(a => a.Id)
                .ProjectTo<AdvertViewModel>()
                .ToList();

                return View(adverts.ToPagedList(page, ItemsPerPage));
            }
            catch (Exception)
            {
                this.TempData["Notification"] = "Exeption.";

                return RedirectToAction("Index", "Home");
            }
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
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

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
                return View(model);
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