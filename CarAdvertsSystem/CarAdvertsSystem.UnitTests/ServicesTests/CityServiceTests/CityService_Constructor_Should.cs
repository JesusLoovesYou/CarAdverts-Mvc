using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.CityServiceTests
{
    [TestFixture]
    public class CityService_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExeption_IfParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efDataProvider = null;

            // Act and Assert
            Assert.That(() => new CityService(efDataProvider),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorShould_ReturnNewInstanceOfCityService_IfParameterIsValid()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var cityService = new CityService(mockedEfProvider.Object);

            // Assert
            Assert.That(cityService, Is.Not.Null);
        }

    }
}
