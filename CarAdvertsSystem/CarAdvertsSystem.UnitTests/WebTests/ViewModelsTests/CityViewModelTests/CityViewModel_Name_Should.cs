using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.CityViewModelTests
{
    [TestFixture]
    public class CityViewModel_Name_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new CityViewModel() { Name = test };

            // Assert
            Assert.AreEqual(test, viewModel.Name);
        }
    }
}
