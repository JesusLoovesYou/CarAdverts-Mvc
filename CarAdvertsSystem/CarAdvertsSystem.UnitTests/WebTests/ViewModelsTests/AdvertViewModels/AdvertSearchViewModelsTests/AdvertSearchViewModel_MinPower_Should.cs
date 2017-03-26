using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_MinPower_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new AdvertSearchViewModel { MinPower = test };

            // Assert
            Assert.AreEqual(test, viewModel.MinPower);
        }
    }
}
