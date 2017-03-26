using CarAdverts.Models;
using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.FileViewModelTests
{
    [TestFixture]
    public class FileViewModel_FileType_Should
    {
        [TestCase(FileType.Photo)]
        [TestCase(FileType.Avatar)]
        public void GetAndSetDataCorrectly(FileType test)
        {
            // Arrange and Act
            var viewModel = new FileViewModel { FileType = test };

            // Assert
            Assert.AreEqual(test, viewModel.FileType);
        }
    }
}
