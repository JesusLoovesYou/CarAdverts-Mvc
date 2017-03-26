using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenModelParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Arrange
            Assert.Throws<ArgumentNullException>(() => ajaxAdvertController.Add(null));
        }

        [Test]
        public void RedirectToActionIndex_WhennModelStateIsNotValid()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);
            ajaxAdvertController.ModelState.AddModelError("test", "test");

            // Arrange
            ajaxAdvertController
                .WithCallTo(x => x.Add(new AdvertViewModel()))
                .ShouldRedirectTo(x => x.Index);
        }

        [Test]
        public void InvokeAdvertServiceMethod_CreateAdvert_Once_WhennModelStateIsValid()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var advertViewModel = new AdvertViewModel()
            {
                Title = "advert",
                VehicleModelId = 1,
                UserId = "user id",
                Year = 100,
                Price = 100m,
                Power = 100,
                DistanceCoverage = 100,
                CityId = 1,
                Description = "ani description",
                CreatedOn = DateTime.Now
            };

            var advertService = new Mock<IAdvertService>();
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);
            ajaxAdvertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), ajaxAdvertController);

            // Act
            ajaxAdvertController.Add(advertViewModel);

            // Arrange
            advertService.Verify(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()), Times.Once);
        }

        [Test]
        public void ReturnJsonWithCorrectModel_WhennModelStateIsValid()
        {
            // Arrange
            // This code mock User.Identity.GetUserId()
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dominik.ernst@xyz123.de");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);
            //

            var advertViewModel = new AdvertViewModel()
            {
                Title = "advert",
                VehicleModelId = 1,
                Year = 100,
                Price = 100m,
                Power = 100,
                DistanceCoverage = 100,
                CityId = 1,
                Description = "ani description",
                CreatedOn = DateTime.Now
            };

            var advertService = new Mock<IAdvertService>();
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);
            ajaxAdvertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), ajaxAdvertController);
            
            // Act and Arrange
            ajaxAdvertController
                .WithCallTo(x => x.Add(advertViewModel))
                .ShouldReturnJson(data =>
                {
                    Assert.AreEqual(data.Title, advertViewModel.Title);
                    Assert.AreEqual(data.VehicleModelId, advertViewModel.VehicleModelId);
                    Assert.AreEqual(data.Year, advertViewModel.Year);
                    Assert.AreEqual(data.Price, advertViewModel.Price);
                    Assert.AreEqual(data.Power, advertViewModel.Power);
                    Assert.AreEqual(data.DistanceCoverage, advertViewModel.DistanceCoverage);
                    Assert.AreEqual(data.CityId, advertViewModel.CityId);
                    Assert.AreEqual(data.Description, advertViewModel.Description);
                    Assert.AreEqual(data.CreatedOn, advertViewModel.CreatedOn);
                });

        }
    }
}
