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

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CRUDAdvertController(advertService));
        }

        [Test]
        public void CreateInstanceOfAdvertController_WhenAdvertServiceParameterIsNotNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var crudAdvertController = new CRUDAdvertController(advertService.Object);

            // Act and Assert
            Assert.That(crudAdvertController, Is.Not.Null);
            Assert.IsInstanceOf<CRUDAdvertController>(crudAdvertController);
        }
    }
}
