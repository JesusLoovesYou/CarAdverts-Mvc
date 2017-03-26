using System.ComponentModel.DataAnnotations;
using System.Linq;
using CarAdverts.Web.Models;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.ManufacturerViewModelTests
{
    [TestFixture]
    public class ManufacturerViewModel_Name_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new ManufacturerViewModel() { Name = test };

            // Assert
            Assert.AreEqual(test, viewModel.Name);
        }
    }
}
