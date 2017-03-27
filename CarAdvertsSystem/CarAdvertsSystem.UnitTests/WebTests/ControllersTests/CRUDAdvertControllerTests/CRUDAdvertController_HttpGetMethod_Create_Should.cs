using CarAdverts.Services.Contracts;
using CarAdverts.Web.Areas.User.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.CRUDAdvertControllerTests
{
    [TestFixture]
    public class CRUDAdvertController_HttpGetMethod_Create_Should
    {
        [Test]
        public void ReturnCorrectActionResult()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            var cityService = new Mock<ICityService>();
            var modelService = new Mock<IVehicleModelService>();

            var advertController = new CRUDAdvertController(advertService.Object, cityService.Object, modelService.Object);


            // Act
            advertController.WithCallTo(x => x.Create()).ShouldRenderDefaultView();

        }
    }
}
