using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web;
using CarAdverts.Web.Controllers;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertController_Index_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void ReturnHttpStatusCode_BadRequest_IfModelParameterIsNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(mockedAdvertService.Object);

            // Act and Assert
            advertController
                .WithCallTo(x => x.Index(null, 1))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }
        
        [Test]
        public void SetTempDataNotificationWithCorrectMessage_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(mockedAdvertService.Object);
            advertController.ModelState.AddModelError("test", "test");

            // Act 
            advertController.Index(new AdvertSearchViewModel(), 1);

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exeption.");
        }
        
        [Test]
        public void RedirectTo_ControllerHome_MethodIndex_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(mockedAdvertService.Object);
            advertController.ModelState.AddModelError("test", "test");

            // Act and Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel(), 1))
                .ShouldRedirectTo<CarAdverts.Web.Controllers.HomeController>(h => h.Index());
        }
        
        [Test]
        public void InvokeAdvertServiceMethod_Search_Once_IfModelStateIsValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(mockedAdvertService.Object);
            advertController.Index(new AdvertSearchViewModel(), 1);

            // Act and Assert
            mockedAdvertService.Verify(a => a.Search(
                                                    It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                                                    It.IsAny<int?>(), It.IsAny<decimal?>(), It.IsAny<decimal?>(),
                                                    It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>()), Times.Once);
        }
        
        [Test]
        public void InvokeAdvertServiceMethod_Search_Never_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(mockedAdvertService.Object);
            advertController.ModelState.AddModelError("test", "test");

            advertController.Index(new AdvertSearchViewModel(), 1);

            // Act and Assert
            mockedAdvertService.Verify(a => a.Search(
                                                    It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                                                    It.IsAny<int?>(), It.IsAny<decimal?>(), It.IsAny<decimal?>(),
                                                    It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>()), Times.Never);
        }
        
        [Test]
        public void ReturnDefaultViewWithCorrectModel_IfNoOcureError()
        {
            // Arrange
            var adverts = new List<Advert>()
            {
                new Advert() { Id = 1, CityId = 1, Price = 100, Power = 100 }
            }.AsQueryable();
            
            var mockedAdvertService = new Mock<IAdvertService>();
            mockedAdvertService.Setup(x => x.Search(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(adverts);
            var advertController = new AdvertController(mockedAdvertService.Object);
            
            // Act and Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel(), 1))
                .ShouldRenderDefaultView();
        }
        
        [Test]
        public void SetTempDataNotificationWithCorrectMessage_IfOcureError()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            mockedAdvertService.Setup(a => a.Search(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                It.IsAny<int?>(), It.IsAny<decimal?>(), It.IsAny<decimal?>(),
                It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>())).Throws(new Exception());

            var advertController = new AdvertController(mockedAdvertService.Object);

            // Act 
            advertController.Index(new AdvertSearchViewModel(), 1);

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exeption.");
        }
        
        [Test]
        public void RedirectTo_ControllerHome_MethodIndex_IfOcureError()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            mockedAdvertService.Setup(a => a.Search(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(),
                It.IsAny<int?>(), It.IsAny<decimal?>(), It.IsAny<decimal?>(),
                It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<int?>())).Throws(new Exception());

            var advertController = new AdvertController(mockedAdvertService.Object);
            
            // Act and Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel(), 1))
                .ShouldRedirectTo<CarAdverts.Web.Controllers.HomeController>(h => h.Index());
        }
    }
}
