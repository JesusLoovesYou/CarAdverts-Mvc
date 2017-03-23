using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using TestStack.FluentMVCTesting;
using CarAdverts.Web.Models.Advert;
using System.Collections.Generic;
using System.Web;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertController_HttpPostMethod_Create_Should
    {
        [Test]
        public void ReturnDefaultViewWithAdvertInputViewModel_WhenModelStateIsNivalid()
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


    }
}
