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

            string userId;
            if (User.Identity.IsAuthenticated)
            {
                userId = User.Identity.GetUserId();
            }

            var advert = new Advert()
            {
                Title = model.Title,
                VehicleModelId = model.VehicleModelId,
                UserId = this.User.Identity.GetUserId(),
                Year = model.Year,
                Price = model.Price,
                Power = model.Power,
                DistanceCoverage = int.Parse(model.DistanceCoverage),
                CityId = int.Parse(model.CityId),
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
            return Json(advert, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Advert emp)
        {
            this.provider.Adverts.Update(emp);

            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var adv = this.provider.Adverts.GetById(id);
            this.provider.Adverts.Delete(id);

            return Json(adv, JsonRequestBehavior.AllowGet);
        }

    }
}