using System;
using NUnit.Framework;
using Moq;
using CarAdverts.Web.Models.Advert;
using CarAdverts.Services.Contracts;
using CarAdverts.Models;
using CarAdverts.Web.Controllers;
using TestStack.FluentMVCTesting;
using System.Net;
using CarAdverts.Web;
using System.Reflection;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertController_Detail_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void HttpStatusCode_BadRequest_WhenIdParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(advertService.Object);

            // Act and Assert
            advertController
                .WithCallTo(c => c.Detail(null))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }
        
        [Test]
        public void InvokeAdvertServiceMethod_GetById_Once_WhenIdParameterIsNotNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(advertService.Object);

            // Act
            advertController.Detail(1);

            // Assert
            advertService.Verify(a => a.GetById(It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void InvokeAdvertServiceMethod_GetById_Never_WhenIdParameterIsNull()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            var advertController = new AdvertController(advertService.Object);

            // Act
            advertController.Detail(null);

            // Assert
            advertService.Verify(a => a.GetById(It.IsAny<int?>()), Times.Never);
        }
        
        [Test]
        public void ReturnHttpStatusCode_NotFound_WhenNotFindAdvert()
        {
            // Arrange
            Advert advert = null;
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.GetById(It.IsAny<int?>())).Returns(advert);

            var advertController = new AdvertController(advertService.Object);

            // Act and Assert
            advertController
                .WithCallTo(c => c.Detail(1))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        // else return view with model
        [Test]
        public void ReturnDefaultView_WithCorrectModel_WhenAdvertIsFinded()
        {
            // Arrange
            var createdOn = DateTime.Now;
            Advert advert = new Advert()
            {
                Id = 1,
                Title = "Title",
                CreatedOn = createdOn
            };
            
            var advertViewModel = new AdvertViewModel()
            {
                Id = advert.Id,
                Title = advert.Title,
                CreatedOn = advert.CreatedOn
            };
            
            var advertService = new Mock<IAdvertService>();
            advertService.Setup(a => a.GetById(It.IsAny<int?>())).Returns(advert);

            var advertController = new AdvertController(advertService.Object);

            // Act and Assert
            advertController
                .WithCallTo(c => c.Detail(1))
                .ShouldRenderDefaultView()
                .WithModel<AdvertViewModel>(x => 
                {
                    Assert.AreEqual(x.Id, advertViewModel.Id);
                    Assert.AreEqual(x.Title, advertViewModel.Title);
                    Assert.AreEqual(x.CreatedOn, advertViewModel.CreatedOn);
                });
        }

    }
}
