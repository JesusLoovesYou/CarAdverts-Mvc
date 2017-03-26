using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Areas.Administrator.Controllers
{
    public class AjaxAdvertController : BaseController
    {
        private readonly IAdvertService advertService;

        public AjaxAdvertController(IAdvertService advertService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();

            this.advertService = advertService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            var adverts = this.advertService
               .All()
               .ProjectTo<AdvertViewModel>()
               .ToList();

            return Json(adverts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(AdvertViewModel model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "AjaxAdvert");
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

            this.advertService.CreateAdvert(advert, null);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var advert = this.advertService.GetById(id);
            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(AdvertViewModel model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "AjaxAdvert");
            }

            var advert = this.advertService.GetById(model.Id);
            advert.Title = model.Title;
            advert.VehicleModelId = model.VehicleModelId;
            advert.Year = model.Year;
            advert.Price = model.Price;
            advert.Power = model.Power;
            advert.DistanceCoverage = model.DistanceCoverage;
            advert.CityId = model.CityId;
            advert.Description = model.Description;
            advert.Id = model.Id;
            advert.UserId = model.UserId;

            this.advertService.Update(advert);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var advert = this.advertService.GetById(id);

            this.advertService.Delete(advert);

            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}