using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_Power_Should
    {
        [TestCase(1)]
        [TestCase(3)]
        public void GetAndSetIdCorrectly(int testPower)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { Power = testPower };

            // Assert
            Assert.AreEqual(testPower, viewModel.Power);
        }
    }
}
