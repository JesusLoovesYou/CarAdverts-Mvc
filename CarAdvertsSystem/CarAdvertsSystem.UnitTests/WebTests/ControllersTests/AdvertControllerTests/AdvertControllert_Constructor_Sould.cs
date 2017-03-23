using System;
using NUnit.Framework;
using Moq;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using CarAdverts.Data.Providers.EfProvider;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertControllert_Constructor_Sould
    {
        [Test]
        public void ThrowArgumentNullException_WhenEfProviderParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efProvider = null;
            var advertService = new Mock<IAdvertService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AdvertController(efProvider, advertService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenAdvertServiceParameterIsNull()
        {
            // Arrange
            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            IAdvertService advertService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AdvertController(efProvider.Object, advertService));
        }
        
        [Test]
        public void CreateInstanceOfAdvertService_WhenFileServiceParameterIsNotNull()
        {
            // Arrange
            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            var advertService = new Mock<IAdvertService>();

            // Act
            var advertController = new AdvertController(efProvider.Object, advertService.Object);

            // Act and Assert
            Assert.That(advertController, Is.Not.Null);
            Assert.IsInstanceOf<AdvertController>(advertController);
        }
    }
}
