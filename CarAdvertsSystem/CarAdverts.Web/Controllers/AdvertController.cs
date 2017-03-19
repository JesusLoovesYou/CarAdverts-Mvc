using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarAdverts.Web.Controllers
{
    public class AdvertController : Controller
    {
        private const int ItemsPerPage = 1;

        private IEfCarAdvertsDataProvider provider;

        public AdvertController(IEfCarAdvertsDataProvider provider,
            IEfDeletableRepository<CarAdverts.Models.Advert> testadvert)
        {
            this.provider = provider;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.provider.Adverts.All().Count();
            var totalpages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var adverts = this.provider.Adverts
                .All()
                .OrderBy(a => a.CreatedOn)
                .ThenBy(a => a.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .ProjectTo<AdvertViewModel>()
                .ToList();

            var viewModel = new PageableAdvertsListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalpages,
                Adverts = adverts
            };

            return View(viewModel);
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
        public ActionResult Create(AdvertInputViewModel model)
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
            
            this.provider.Adverts.Add(advert);
            this.provider.SaveChanges();

            this.TempData["Notification"] = "Succesfull advert creation.";

            return Redirect("/");
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}