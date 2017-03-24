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
        public void ThrowArgumentNullException_WhenAdvertServiceParameterIsNull()
        {
            // Arrange
            IAdvertService advertService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AdvertController(advertService));
        }
        
        [Test]
        public void CreateInstanceOfAdvertService_WhenAdvertServiceParameterIsNotNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var advertController = new AdvertController(advertService.Object);

            // Act and Assert
            Assert.That(advertController, Is.Not.Null);
            Assert.IsInstanceOf<AdvertController>(advertController);
        }
    }
}
