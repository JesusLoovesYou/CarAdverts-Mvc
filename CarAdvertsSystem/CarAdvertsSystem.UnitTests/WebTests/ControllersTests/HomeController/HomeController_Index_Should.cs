using System.Collections.Generic;
using System.Reflection;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using System.Linq;
using System.Web.Mvc;
using CarAdverts.Common.Generator;
using CarAdverts.Web;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.HomeController
{
    [TestFixture]
    public class HomeController_Index_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void CreateViewBack_Categories_WithCorrectValue()
        {
            // Arrange
            var categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Car"},
                new Category() { Id = 1, Name = "Bus"},
            }.AsQueryable();

            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Id = 1, Name = "Audi"},
                new Manufacturer() { Id = 1, Name = "Fiat"},
            }.AsQueryable();

            var models = new List<VehicleModel>()
            {
                new VehicleModel() { Id = 1, Name = "A4"},
                new VehicleModel() { Id = 1, Name = "TT"},
            }.AsQueryable();

            var cities = new List<City>()
            {
                new City() { Id = 1, Name = "Dupnitca"},
                new City() { Id = 1, Name = "Sofia"},
            }.AsQueryable();

            
            var mockedEfRepositoryCategory = new Mock<IEfGenericRepository<Category>>();
            mockedEfRepositoryCategory.Setup(x => x.All()).Returns(categories);

            var mockedEfRepositoryManufacturer = new Mock<IEfGenericRepository<Manufacturer>>();
            mockedEfRepositoryManufacturer.Setup(x => x.All()).Returns(manufacturers);

            var mockedEfRepositoryVehicleModel = new Mock<IEfGenericRepository<VehicleModel>>();
            mockedEfRepositoryVehicleModel.Setup(x => x.All()).Returns(models);
            
            var mockedEfRepositoryVehicleCity = new Mock<IEfGenericRepository<City>>();
            mockedEfRepositoryVehicleCity.Setup(x => x.All()).Returns(cities);

            var mockedGenerator = new Mock<IGenerator>();

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            efProvider.Setup(x => x.Categories).Returns(mockedEfRepositoryCategory.Object);
            efProvider.Setup(x => x.Manufacturers).Returns(mockedEfRepositoryManufacturer.Object);
            efProvider.Setup(x => x.VehicleModels).Returns(mockedEfRepositoryVehicleModel.Object);
            efProvider.Setup(x => x.Cities).Returns(mockedEfRepositoryVehicleCity.Object);

            var homeController = new CarAdverts.Web.Controllers.HomeController(efProvider.Object, mockedGenerator.Object);

            // Act
            homeController.Index();

            // Assert
            Assert.IsNotNull(homeController.ViewBag.Categories as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Manufacturers as SelectList);
            Assert.IsNotNull(homeController.ViewBag.VehicleModels as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Cities as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Years as SelectList);
        }

        [Test]
        public void ReturnDefoltView()
        {
            // Arrange
            var categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Car"},
                new Category() { Id = 1, Name = "Bus"},
            }.AsQueryable();

            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Id = 1, Name = "Audi"},
                new Manufacturer() { Id = 1, Name = "Fiat"},
            }.AsQueryable();

            var models = new List<VehicleModel>()
            {
                new VehicleModel() { Id = 1, Name = "A4"},
                new VehicleModel() { Id = 1, Name = "TT"},
            }.AsQueryable();

            var cities = new List<City>()
            {
                new City() { Id = 1, Name = "Dupnitca"},
                new City() { Id = 1, Name = "Sofia"},
            }.AsQueryable();


            var mockedEfRepositoryCategory = new Mock<IEfGenericRepository<Category>>();
            mockedEfRepositoryCategory.Setup(x => x.All()).Returns(categories);

            var mockedEfRepositoryManufacturer = new Mock<IEfGenericRepository<Manufacturer>>();
            mockedEfRepositoryManufacturer.Setup(x => x.All()).Returns(manufacturers);

            var mockedEfRepositoryVehicleModel = new Mock<IEfGenericRepository<VehicleModel>>();
            mockedEfRepositoryVehicleModel.Setup(x => x.All()).Returns(models);

            var mockedEfRepositoryVehicleCity = new Mock<IEfGenericRepository<City>>();
            mockedEfRepositoryVehicleCity.Setup(x => x.All()).Returns(cities);

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            efProvider.Setup(x => x.Categories).Returns(mockedEfRepositoryCategory.Object);
            efProvider.Setup(x => x.Manufacturers).Returns(mockedEfRepositoryManufacturer.Object);
            efProvider.Setup(x => x.VehicleModels).Returns(mockedEfRepositoryVehicleModel.Object);
            efProvider.Setup(x => x.Cities).Returns(mockedEfRepositoryVehicleCity.Object);

            var mockedGenerator = new Mock<IGenerator>();

            var homeController = new CarAdverts.Web.Controllers.HomeController(efProvider.Object, mockedGenerator.Object);

            // Act and assert
            homeController
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }
    }
}
