using System;
using CarAdverts.Common.Generator;
using CarAdverts.Data.Providers.EfProvider;
using Castle.DynamicProxy.Generators;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.HomeController
{
    [TestFixture]
    public class HomeController_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenEfDataProviderParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efProvider = null;
            var generator = new Mock<IGenerator>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdverts.Web.Controllers.HomeController(efProvider, generator.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGeneratorParameterIsNull()
        {
            // Arrange
            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            IGenerator generator = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdverts.Web.Controllers.HomeController(efProvider.Object, generator));
        }

        [Test]
        public void CreateInstanceOfHometController_WhenEfDataProviderParameterIsNotNull()
        {
            // Arrange
            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            var generator = new Mock<IGenerator>();

            // Act
            var homeController = new CarAdverts.Web.Controllers.HomeController(efProvider.Object, generator.Object);

            // Act and Assert
            Assert.That(homeController, Is.Not.Null);
            Assert.IsInstanceOf<CarAdverts.Web.Controllers.HomeController>(homeController);
        }


    }
}
