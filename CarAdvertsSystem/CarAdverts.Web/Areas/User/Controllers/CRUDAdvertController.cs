using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarAdverts.Common.Generator;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Areas.User.Controllers
{
    public class CRUDAdvertController : Controller
    {
        private readonly IAdvertService advertService;

        private readonly ICityService cityService;

        private readonly IVehicleModelService vehicleModelService;

        private readonly IGenerator generator;

        public CRUDAdvertController(IAdvertService advertService, ICityService cityService, IVehicleModelService vehicleModelService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();
            Guard.WhenArgument(cityService, nameof(cityService)).IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, nameof(vehicleModelService)).IsNull().Throw();

            this.advertService = advertService;
            this.cityService = cityService;
            this.vehicleModelService = vehicleModelService;
        }

        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Create()
        {
            var vehicleModels = this.vehicleModelService.All().ProjectTo<VehicleModelViewModel>().ToList();
            var cities = this.cityService.All().ProjectTo<CityViewModel>().ToList();
            
            ViewBag.VehicleModels = new SelectList(vehicleModels, "Id", "Name");
            ViewBag.Cities = new SelectList(cities, "Id", "Name");

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

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}