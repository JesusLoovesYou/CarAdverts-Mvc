using System.Reflection;
using CarAdverts.Services.Contracts;
using CarAdverts.Web;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_GetById_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void InvokeAdvertServiceMethod_GetById_Once()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act
            ajaxAdvertController.GetById(1);

            // Arrange
            advertService.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();
            
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Act and Arrange
            ajaxAdvertController
                .WithCallTo(x => x.GetById(1));
        }



    }
}
