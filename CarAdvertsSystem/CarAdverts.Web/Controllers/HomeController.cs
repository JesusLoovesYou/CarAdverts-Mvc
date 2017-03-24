using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Web.Models;

namespace CarAdverts.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEfCarAdvertsDataProvider provider;

        public HomeController(IEfCarAdvertsDataProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = provider.Categories.All().ProjectTo<CategoryViewModel>().ToList();
            var manufacturers = provider.Manufacturers.All().ProjectTo<ManufacturerViewModel>().ToList();
            var vehicleModels = provider.VehicleModels.All().ProjectTo<VehicleModelViewModel>().ToList();
            var cities = provider.Cities.All().ProjectTo<CityViewModel>().ToList();
            var years = this.NumbersGenerator(1970, DateTime.Now.Year);

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

        private IEnumerable<int> NumbersGenerator(int min, int max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }

            var numbers = new List<int>();

            for (int i = max; i >= min; i--)
            {
                numbers.Add(i);
            }

            return numbers;
        }

    }
}