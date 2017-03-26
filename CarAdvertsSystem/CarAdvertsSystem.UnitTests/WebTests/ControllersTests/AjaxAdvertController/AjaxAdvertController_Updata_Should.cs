using System;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_Updata_Should
    {

        [Test]
        public void ThrowArgumentNullException_WhenModelParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Arrange
            Assert.Throws<ArgumentNullException>(() => ajaxAdvertController.Update(null));
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
                .WithCallTo(x => x.Update(new AdvertViewModel()))
                .ShouldRedirectTo(x => x.Index);
        }

        [Test]
        public void InvokeAdvertServiceMethod_Update_Once_WhennModelStateIsValid()
        {
            // Arrange
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
            advertService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Advert());

            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act
            ajaxAdvertController.Update(advertViewModel);

            // Assert
            advertService.Verify(a => a.Update(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void ReturnJsonWithCorrectModel_WhennModelStateIsValid()
        {
            // Arrange

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
            advertService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Advert());

            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act and Arrange
            ajaxAdvertController
                .WithCallTo(x => x.Update(advertViewModel))
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
