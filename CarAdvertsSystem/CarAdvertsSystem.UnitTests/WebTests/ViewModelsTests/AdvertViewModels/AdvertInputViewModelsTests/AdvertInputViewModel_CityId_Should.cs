using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_CityId_Should
    {
        [Test]
        public void HaveTheAllolHtmlAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("CityId");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(DisplayAttribute), true)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(3)]
        public void GetAndSetDataCorrectly(int testCityId)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { CityId = testCityId };

            // Assert
            Assert.AreEqual(testCityId, viewModel.CityId);
        }
    }
}
