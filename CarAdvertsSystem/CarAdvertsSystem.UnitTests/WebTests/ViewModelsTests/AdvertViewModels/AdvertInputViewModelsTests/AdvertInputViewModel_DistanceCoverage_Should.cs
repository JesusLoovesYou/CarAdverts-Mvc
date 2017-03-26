using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_DistanceCoverage_Should
    {
        [TestCase(1)]
        [TestCase(3000)]
        public void GetAndSetIdCorrectly(int testDistanceCoverage)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { DistanceCoverage = testDistanceCoverage };

            // Assert
            Assert.AreEqual(testDistanceCoverage, viewModel.DistanceCoverage);
        }
    }
}
