using System.Reflection;
using CarAdverts.Services.Contracts;
using CarAdverts.Web;
using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.AjaxAdvertController
{
    [TestFixture]
    public class AjaxAdvertController_List_Should
    {
        [TestFixtureSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarAdverts.Web"));
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel()
        {
            // Arrange
            var advertService = new Mock<IAdvertService>();

            // Act
            var ajaxAdvertController = new CarAdverts.Web.Areas.Administrator.Controllers.AjaxAdvertController(advertService.Object);

            // Arrange
            ajaxAdvertController
                .WithCallTo(x => x.List())
                .ShouldReturnJson();
        }
    }
}
