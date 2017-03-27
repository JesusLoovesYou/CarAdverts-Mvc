using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.CityServiceTests
{
    public class CityService_All_Should
    {
        [Test]
        public void InvokeEfProviderCitiesMethod_All_Once()
        {
            // Arrange
            var mockedCityRepository = new Mock<IEfDeletableRepository<City>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Cities).Returns(mockedCityRepository.Object);

            var cityService = new CityService(mockedEfProvider.Object);

            // Act
            var result = cityService.All();

            // Assert
            mockedCityRepository.Verify(p => p.All(), Times.Once);
        }

        [Test]
        public void ReturnCorrectCities()
        {
            // Arrange
            var expectedCities = new List<City>()
            {
                new City() { Id = 1, Name = "Test 1" },
                new City() { Id = 2, Name = "Test 2"  },
                new City() { Id = 3, Name = "Test 3"  }
            }.AsQueryable();

            var mockedCityRepository = new Mock<IEfGenericRepository<City>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            mockedCityRepository.Setup(x => x.All()).Returns(expectedCities);
            mockedEfProvider.Setup(p => p.Cities).Returns(mockedCityRepository.Object);

            var cityService = new CityService(mockedEfProvider.Object);

            // Act
            var result = cityService.All();

            // Assert
            Assert.AreEqual(result, expectedCities);
        }

    }
}
