using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.CategoryViewModel
{
    [TestFixture]
    public class CategoryViewModel_Id_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new CarAdverts.Web.Models.CategoryViewModel() { Id = test };

            // Assert
            Assert.AreEqual(test, viewModel.Id);
        }
    }
}
