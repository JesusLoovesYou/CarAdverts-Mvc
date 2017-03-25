using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Areas.Adminstrator.Controllers
{
    public class AjaxAdvertController : Controller
    {
        private readonly IAdvertService advertService;

        public AjaxAdvertController(IAdvertService advertService)
        {
            this.advertService = advertService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] // M - A
        public JsonResult List(string filter)
        {
            var adverts = this.advertService
               .All();

            if (filter == "title")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "modelId")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "year")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "price")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "power")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "distCoverage")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "cityId")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "description")
            {
                adverts.OrderBy(x => x.Title);
            }

            var model = adverts
                .ProjectTo<AdvertViewModel>()
                .ToList();

            var result = Json(model, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;
            return result;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Add(AdvertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(null, null);
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
                this.advertService.CreateAdvert(advert, null);
            }
            catch (Exception e)
            {
                // Notification
                // neznam
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var advert = this.advertService.GetById(id);
            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            var result = Json(model, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Update(AdvertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(null, null);
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

            try
            {
                this.advertService.Update(advert);
            }
            catch (Exception e)
            {
                // Notification error
                // neznam
            }
            
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var advert = this.advertService.GetById(id);

            this.advertService.Delete(advert);

            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);
            
            var result = Json(model, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        [HttpGet]
        public JsonResult Filter(string filter)
        {
            var adverts = this.advertService
                .All();

            if (filter == "title")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "modelId")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "year")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "price")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "power")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "distCoverage")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "cityId")
            {
                adverts.OrderBy(x => x.Title);
            }
            else if (filter == "description")
            {
                adverts.OrderBy(x => x.Title);
            }

            var model = adverts
                .ProjectTo<AdvertViewModel>()
                .ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}