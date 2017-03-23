using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using TestStack.FluentMVCTesting;
using CarAdverts.Web.Models.Advert;
using System.Collections.Generic;
using System.Web;
using CarAdverts.Models;
using System.Security.Principal;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;
using System;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertController_HttpPostMethod_Create_Should
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act and Assert
            advertController
                .WithCallTo(c => c.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertInputViewModel>(x => 
                {
                    Assert.IsNull(x.Title);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            var advertService = new Mock<IAdvertService>();
            var advertController = new AdvertController(efProvider.Object, advertService.Object);

            advertController.ModelState.AddModelError("test", "test");

            // Act and Assert
            advertController
                .WithCallTo(x => x.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertInputViewModel>(x =>
                {
                    Assert.IsNull(x.Description);
                    Assert.IsNull(x.Title);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
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

            var efProvider = new Mock<IEfCarAdvertsDataProvider>();

            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(efProvider.Object, advertService.Object);
            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            advertController.WithCallTo(a => a.Create(model, uploadedFiles)).ShouldRedirectTo("/");
        }
    }
}
