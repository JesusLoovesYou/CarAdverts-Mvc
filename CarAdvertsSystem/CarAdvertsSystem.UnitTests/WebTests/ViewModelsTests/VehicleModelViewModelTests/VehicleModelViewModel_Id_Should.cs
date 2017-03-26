using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.VehicleModelViewModelTests
{
    [TestFixture]
    public class VehicleModelViewModel_Id_Should
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new VehicleModelViewModel() { Id = test };

            // Assert
            Assert.AreEqual(test, viewModel.Id);
        }
    }
}
