using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Areas.User.Controllers;
using CarAdverts.Web.Controllers;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.CRUDAdvertControllerTests
{
    [TestFixture]
    public class CRUDAdvertController_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertServiceParameterIsNull()
        {
            // Arrange
            IAdvertService advertService = null;
            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => 
                new CRUDAdvertController(advertService, cityService.Object, modelService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCityServiceParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            ICityService cityService = null;
            var modelService = new Mock<IVehicleModelService>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CRUDAdvertController(advertService.Object, cityService, modelService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenAVehicleModelServiceParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            var cityService = new Mock<ICityService>();
            IVehicleModelService modelService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CRUDAdvertController(advertService.Object, cityService.Object, modelService));
        }

        [Test]
        public void CreateInstanceOfAdvertController_WhenAdvertServiceParameterIsNotNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            // Act
            var crudAdvertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);

            // Act and Assert
            Assert.That(crudAdvertController, Is.Not.Null);
            Assert.IsInstanceOf<CRUDAdvertController>(crudAdvertController);
        }
    }
}
