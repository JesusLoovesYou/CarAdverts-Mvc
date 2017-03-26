using System;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_Constuctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertServiceParameterIsNull()
        {
            // Arrange
            IAdvertService advertService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService));
        }

        [Test]
        public void CreateInstanceOfAjaxAdvertController_WhenAdvertServiceParameterIsNotNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act and Assert
            Assert.That(ajaxAdvertController, Is.Not.Null);
            Assert.IsInstanceOf<CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController>(ajaxAdvertController);
        }
    }
}
