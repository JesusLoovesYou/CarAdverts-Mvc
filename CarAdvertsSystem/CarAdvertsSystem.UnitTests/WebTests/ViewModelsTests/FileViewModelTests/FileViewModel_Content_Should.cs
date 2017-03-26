using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.FileViewModelTests
{
    [TestFixture]
    public class FileViewModel_Content_Should
    {
        [Test]
        public void GetAndSetDataCorrectly()
        {
            // Arrange and Act
            var testArray = new byte[5];
            var viewModel = new FileViewModel { Content = testArray };

            // Assert
            Assert.AreEqual(testArray.Length, viewModel.Content.Length);
        }
    }
}
