using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Areas.User.Controllers
{
    public class CRUDAdvertController : Controller
    {
        private readonly IAdvertService advertService;

        public CRUDAdvertController(IAdvertService advertService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();

            this.advertService = advertService;
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

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}