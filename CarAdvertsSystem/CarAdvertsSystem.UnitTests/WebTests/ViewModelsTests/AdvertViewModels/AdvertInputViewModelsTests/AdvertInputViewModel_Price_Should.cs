using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_Price_Should
    {
        [TestCase(1)]
        [TestCase(330.3d)]
        public void GetAndSetDataCorrectly(decimal testPrice)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { Price = testPrice };

            // Assert
            Assert.AreEqual(testPrice, viewModel.Price);
        }
    }
}
