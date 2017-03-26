using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_VehicleModelId_Should
    {
        [Test]
        public void HaveTheDisplayAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertSearchViewModel).GetProperty("VehicleModelId");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(DisplayAttribute), true)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetAndSetDataCorrectly(int testId)
        {
            // Arrange and Act
            var viewModel = new AdvertSearchViewModel { VehicleModelId = testId };

            // Assert
            Assert.AreEqual(testId, viewModel.VehicleModelId);
        }
    }
}
