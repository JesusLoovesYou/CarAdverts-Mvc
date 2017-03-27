using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Areas.User.Controllers;
using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models.Advert;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.CRUDAdvertControllerTests
{
    [TestFixture]
    public class CRUDAdvertController_HttpPostMethod_Create_Should
    {
        [Test]
        public void RedirectToDefaultViewWithCorrectParameterModel_WhenOcuredExceptionOfCreatingInDb()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();
            
            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);
            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act and Assert
            advertController
                .WithCallTo(c => c.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertInputViewModel>(x => 
                {
                    Assert.IsNull(x.Title);
                    Assert.AreEqual(x.VehicleModelId, 0);
                    Assert.AreEqual(x.Year, 0);
                    Assert.AreEqual(x.Price, 0);
                    Assert.AreEqual(x.Power, 0);
                    Assert.AreEqual(x.DistanceCoverage, 0);
                    Assert.AreEqual(x.CityId, 0);
                    Assert.IsNull(x.Description);
                });
        }

        [Test]
        public void SetTempData_NotificationsWithCorrectMessage_WhenOcuredExceptionOfCreatingInDb()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);
            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            //  Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exeption.");
        }

        [Test]
        public void ThrowArgumentNullException_WhenModelParameterIsNull()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            AdvertInputViewModel model = null;
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);
            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => advertController.Create(model, uploadedFiles));
        }

        [Test]
        public void ReturnDefaultViewWithAdvertInputViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);


            advertController.ModelState.AddModelError("test", "test");

            // Act and Assert
            advertController
                .WithCallTo(x => x.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertInputViewModel>(x =>
                {
                    Assert.IsNull(x.Title);
                    Assert.AreEqual(x.VehicleModelId, 0);
                    Assert.AreEqual(x.Year, 0);
                    Assert.AreEqual(x.Price, 0);
                    Assert.AreEqual(x.Power, 0);
                    Assert.AreEqual(x.DistanceCoverage, 0);
                    Assert.AreEqual(x.CityId, 0);
                    Assert.IsNull(x.Description);
                }
            );
        }

        [Test]
        public void InvokeAdvertServiceMethod_CreateAdvert_Once_WhenModelStateIsValid()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            advertService.Verify(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()), Times.Once);
        }
        
        [Test]
        public void SetTempData_Notification_WhenModelStateIsValid_AndThereIsNoExceptions()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Succesfull advert creation.");
        }
        
        [Test]
        public void RedirectToCorrectLinck_WhenModelStateIsValid_AndThereIsNoExceptions()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var model = new AdvertInputViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            advertController
                .WithCallTo(a => a.Create(model, uploadedFiles))
                .ShouldRedirectTo<CarAdverts.Web.Controllers.HomeController>(typeof(CarAdverts.Web.Controllers.HomeController).GetMethod("Index"));
        }
    }
}
