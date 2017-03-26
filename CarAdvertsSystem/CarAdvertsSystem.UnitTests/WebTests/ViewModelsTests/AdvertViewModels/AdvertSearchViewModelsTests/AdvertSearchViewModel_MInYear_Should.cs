using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_MInYear_Should
    {
        [TestCase(1)]
        [TestCase(3)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new AdvertSearchViewModel { MinYear = test };

            // Assert
            Assert.AreEqual(test, viewModel.MinYear);
        }
    }
}
