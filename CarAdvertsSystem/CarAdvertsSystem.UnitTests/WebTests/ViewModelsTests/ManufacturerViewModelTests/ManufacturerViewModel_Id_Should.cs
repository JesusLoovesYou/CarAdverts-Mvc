using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.ManufacturerViewModelTests
{
    [TestFixture]
    public class ManufacturerViewModel_Id_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new ManufacturerViewModel() { Id = test };

            // Assert
            Assert.AreEqual(test, viewModel.Id);
        }
    }
}
