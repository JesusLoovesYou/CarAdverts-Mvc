using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.CategoryViewModel
{
    [TestFixture]
    public class CategoryViewModel_Name_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new CarAdverts.Web.Models.CategoryViewModel() { Name = test };

            // Assert
            Assert.AreEqual(test, viewModel.Name);
        }
    }
}
