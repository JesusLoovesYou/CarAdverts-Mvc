using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Web.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.VehicleModelViewModelTests
{
    [TestFixture]
    public class VehicleModelViewModel_Name_Should
    {
        [TestCase("")]
        [TestCase("test test")]
        public void GetAndSetDataCorrectly(string test)
        {
            // Arrange and Act
            var viewModel = new VehicleModelViewModel() { Name = test };

            // Assert
            Assert.AreEqual(test, viewModel.Name);
        }
    }
}
