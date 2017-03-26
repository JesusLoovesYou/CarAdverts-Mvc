using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.FileViewModelTests
{
    [TestFixture]
    public class FileViewModel_Id_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new FileViewModel { Id = test };

            // Assert
            Assert.AreEqual(test, viewModel.Id);
        }
    }
}
