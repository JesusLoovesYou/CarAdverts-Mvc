using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AdvertControllerTests
{
    [TestFixture]
    public class AdvertController_HttpGetMethod_Create_Should
    {
        [Test]
        public void ReturnCorrectActionResult()
        {
            // Arrange
            var efProvider = new Mock<IEfCarAdvertsDataProvider>();
            var advertService = new Mock<IAdvertService>();
            var advertController = new AdvertController(efProvider.Object, advertService.Object);

            // Act
            advertController.WithCallTo(x => x.Create()).ShouldRenderDefaultView();

        }
    }
}
