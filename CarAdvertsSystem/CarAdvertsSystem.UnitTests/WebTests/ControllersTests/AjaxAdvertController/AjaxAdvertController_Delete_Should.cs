using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_Delete_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void InvokeAdvertServiceMethod_GetById_Once()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act
            ajaxAdvertController.Delete(1);

            // Assert
            advertService.Verify(a => a.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void InvokeAdvertServiceMethod_Delete_Once()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Advert());

            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act
            ajaxAdvertController.Delete(1);

            // Assert
            advertService.Verify(a => a.Delete(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel()
        {
            // Arrange
            var expectedAdvert = new Advert() {Id = 1, Title = "title", Description = "test"};

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(x => x.GetById(It.IsAny<int>())).Returns(expectedAdvert);

            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act
            ajaxAdvertController
                .WithCallTo(x => x.Delete(1))
                .ShouldReturnJson(data =>
                {
                    Assert.AreEqual(data.Id, expectedAdvert.Id);
                    Assert.AreEqual(data.Title, expectedAdvert.Title);
                    Assert.AreEqual(data.Description, expectedAdvert.Description);
                });
        }
    }
}
