using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.FileViewModelTests
{
    [TestFixture]
    public class FileViewModel_Name_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new FileViewModel { Name = test };

            // Assert
            Assert.AreEqual(test, viewModel.Name);
        }
    }
}
