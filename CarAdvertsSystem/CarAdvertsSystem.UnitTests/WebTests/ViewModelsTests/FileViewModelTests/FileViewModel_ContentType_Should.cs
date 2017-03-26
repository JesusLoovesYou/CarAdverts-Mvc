using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.FileViewModelTests
{
    [TestFixture]
    public class FileViewModel_ContentType_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new FileViewModel { ContentType = test };

            // Assert
            Assert.AreEqual(test, viewModel.ContentType);
        }
    }
}
