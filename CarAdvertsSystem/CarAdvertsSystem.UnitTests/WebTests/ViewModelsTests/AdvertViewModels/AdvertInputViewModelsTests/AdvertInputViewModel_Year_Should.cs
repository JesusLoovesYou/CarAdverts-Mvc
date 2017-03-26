using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_Year_Should
    {
        [TestCase(1)]
        [TestCase(3)]
        public void GetAndSetDataCorrectly(int testYear)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { Year = testYear };

            // Assert
            Assert.AreEqual(testYear, viewModel.Year);
        }
    }
}
