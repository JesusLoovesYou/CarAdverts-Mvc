using System.Collections.Generic;
using System.Linq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_Search_Should
    {
        [Test]
        public void ReturnAllAdverts_WhenAllParametersAreNull()
        {
            // Arrange
            IQueryable<Advert> adverts = new List<Advert>()
            {
                new Advert() {Id = 1, Title = "test 1", CityId = 1, Power = 5},
                new Advert() {Id = 2, Title = "test 2", CityId = 5, Power = 7},
            }.AsQueryable();

            var efDeletableAdvertsRepository = new Mock<IEfDeletableRepository<Advert>>();
            efDeletableAdvertsRepository.Setup(x => x.All()).Returns(adverts);

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(x => x.Adverts).Returns(efDeletableAdvertsRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.Search(null, null, null, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result, adverts);
            Assert.AreEqual(result.Count(), adverts.Count());
        }

        [Test]
        public void ReturnAdvertsWithVehicleModelIdEqualOfParameterVehicleModelId_WhenVehicleModelIdParameterIsNotNull()
        {
            // Arrange
            IQueryable<Advert> adverts = new List<Advert>()
            {
                new Advert() { Id = 1, Title = "test 1", CityId = 1, Power = 5, VehicleModelId = 7 },
                new Advert() { Id = 2, Title = "test 2", CityId = 5, Power = 7, VehicleModelId = 1 },
                new Advert() { Id = 3, Title = "test 3", CityId = 5, Power = 6, VehicleModelId = 1 },
            }.AsQueryable();

            var efDeletableAdvertsRepository = new Mock<IEfDeletableRepository<Advert>>();
            efDeletableAdvertsRepository.Setup(x => x.All()).Returns(adverts);

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(x => x.Adverts).Returns(efDeletableAdvertsRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.Search(1, null, null, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result.ToList()[0], adverts.ToList()[1]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[2]);
            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void ReturnAdvertsWithCityIdEqualOfParameterCityId_WhenCityIdParameterIsNotNull()
        {


            // Arrange
            IQueryable<Advert> adverts = new List<Advert>()
            {
                new Advert() {Id = 1, Title = "test 1", CityId = 1, Power = 5},
                new Advert() {Id = 2, Title = "test 2", CityId = 5, Power = 7},
                new Advert() {Id = 3, Title = "test 3", CityId = 5, Power = 6},
            }.AsQueryable();

            var efDeletableAdvertsRepository = new Mock<IEfDeletableRepository<Advert>>();
            efDeletableAdvertsRepository.Setup(x => x.All()).Returns(adverts);

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(x => x.Adverts).Returns(efDeletableAdvertsRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.Search(null, 5, null, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result.ToList()[0], adverts.ToList()[1]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[2]);
            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void ReturnAdvertsWithMinYearEqualOfParameterMinYear_WhenMinYearParameterIsNotNull()
        {
            // Arrange
            IQueryable<Advert> adverts = new List<Advert>()
            {
                new Advert() {Id = 1, Title = "test 1", CityId = 1, Year = 5},
                new Advert() {Id = 2, Title = "test 2", CityId = 5, Year = 100},
                new Advert() {Id = 3, Title = "test 3", CityId = 5, Year = 100},
            }.AsQueryable();

            var efDeletableAdvertsRepository = new Mock<IEfDeletableRepository<Advert>>();
            efDeletableAdvertsRepository.Setup(x => x.All()).Returns(adverts);

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(x => x.Adverts).Returns(efDeletableAdvertsRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.Search(null, null, 100, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result.ToList()[0], adverts.ToList()[1]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[2]);
            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void ReturnAdvertsWithMaxYearEqualOfParameterMaxYear_WhenMaxYearParameterIsNotNull()
        {
            // Arrange
            IQueryable<Advert> adverts = new List<Advert>()
            {
                new Advert() {Id = 1, Title = "test 1", CityId = 1, Year = 5},
                new Advert() {Id = 2, Title = "test 2", CityId = 5, Year = 100},
                new Advert() {Id = 3, Title = "test 3", CityId = 5, Year = 100},
                new Advert() {Id = 3, Title = "test 3", CityId = 5, Year = 101},
            }.AsQueryable();

            var efDeletableAdvertsRepository = new Mock<IEfDeletableRepository<Advert>>();
            efDeletableAdvertsRepository.Setup(x => x.All()).Returns(adverts);

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(x => x.Adverts).Returns(efDeletableAdvertsRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.Search(null, null, null, 100, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result.ToList()[0], adverts.ToList()[0]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[1]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[1]);
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
