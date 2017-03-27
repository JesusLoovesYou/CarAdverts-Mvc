using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Models;
using CarAdverts.Web.Models.Advert;
using CarAdverts.Services.Contracts;
using PagedList;
using Bytes2you.Validation;

namespace CarAdverts.Web.Controllers
{
    public class AdvertController : Controller
    {
        private const int ItemsPerPage = 2;

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