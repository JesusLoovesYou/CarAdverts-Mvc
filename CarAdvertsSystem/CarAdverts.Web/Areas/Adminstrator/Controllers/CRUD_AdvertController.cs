using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services;
using CarAdverts.Services.Contracts;

namespace CarAdverts.Web.Areas.Adminstrator.Controllers
{
    public class CRUD_AdvertController : Controller
    {
        private readonly IAdvertService advertService;

        private readonly IEfCarAdvertsDataProvider provider;

        public CRUD_AdvertController(IAdvertService advertService, IEfCarAdvertsDataProvider provider)
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
            var adverts = provider.Adverts.All().ToList();
            return Json(adverts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Advert emp)
        {
            // Adding addvert
            this.provider.Adverts.Add(emp);
            
            return Json(emp, JsonRequestBehavior.AllowGet);
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