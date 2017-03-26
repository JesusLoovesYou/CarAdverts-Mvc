using CarAdverts.Services.Contracts;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_Index_Should
    {
        [Test]
        public void ReturnDefalutView()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);
            
            // Arrange
            ajaxAdvertController
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }
    }
}
