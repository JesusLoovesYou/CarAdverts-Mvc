using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_MinPrice_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new AdvertSearchViewModel { MinPrice = test };

            // Assert
            Assert.AreEqual(test, viewModel.MinPrice);
        }
    }
}
