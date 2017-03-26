using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarAdverts.Web.Models.Advert;
using NUnit;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_VehicleModelId_Should
    {
        [Test]
        public void HaveTheDisplayAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("VehicleModelId");

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
            var viewModel = new AdvertInputViewModel { VehicleModelId = testId };

            // Assert
            Assert.AreEqual(testId, viewModel.VehicleModelId);
        }
    }
}
