using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Controllers
{
    public class AjaxAdminController : Controller
    {
        private readonly IAdvertService advertService;

        private readonly IEfCarAdvertsDataProvider provider;

        public AjaxAdminController(IAdvertService advertService, IEfCarAdvertsDataProvider provider)
        {
            this.advertService = advertService;
            this.provider = provider;
        }


        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var adverts = provider
                .Adverts
                .All()
                .ProjectTo<AdvertViewModel>()
                .ToList();
            

            return Json(adverts, JsonRequestBehavior.AllowGet);
        }
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
            

            this.provider.Adverts.Add(advert);
            this.provider.SaveChanges();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var advert = this.provider.Adverts.GetById(id);
            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(advert);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(AdvertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(null, null);
            }

            var advert = this.provider.Adverts.GetById(model.Id);
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
                this.provider.Adverts.Update(advert);
                this.provider.SaveChanges();
            }
            catch (Exception e)
            {
                
            }
            

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var adv = this.provider.Adverts.GetById(id);
            this.provider.Adverts.Delete(id);
            this.provider.SaveChanges();

            var model = AutoMapper.Mapper.Map<Advert, AdvertViewModel>(adv);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}