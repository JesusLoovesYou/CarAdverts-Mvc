using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarAdverts.Common.Generator;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Web.Models;

namespace CarAdverts.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEfCarAdvertsDataProvider provider;

        private IGenerator generator;

        public HomeController(IEfCarAdvertsDataProvider provider, IGenerator generator)
        {
            Guard.WhenArgument(provider, nameof(provider)).IsNull().Throw();
            Guard.WhenArgument(generator, nameof(generator)).IsNull().Throw();

            this.provider = provider;
            this.generator = generator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = provider.Categories.All().ProjectTo<CategoryViewModel>().ToList();
            var manufacturers = provider.Manufacturers.All().ProjectTo<ManufacturerViewModel>().ToList();
            var vehicleModels = provider.VehicleModels.All().ProjectTo<VehicleModelViewModel>().ToList();
            var cities = provider.Cities.All().ProjectTo<CityViewModel>().ToList();
            var years = this.generator.GenerateSecuentialNumbers(1970, DateTime.Now.Year);

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
            ViewBag.VehicleModels = new SelectList(vehicleModels, "Id", "Name");
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Years = new SelectList(years, "year");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}