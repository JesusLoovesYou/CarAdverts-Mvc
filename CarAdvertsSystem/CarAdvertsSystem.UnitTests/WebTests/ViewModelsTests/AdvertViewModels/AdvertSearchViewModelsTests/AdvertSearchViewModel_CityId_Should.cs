using System.ComponentModel.DataAnnotations;
using System.Linq;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_CityId_Should
    {
        [Test]
        public void HaveTheDisplayAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertSearchViewModel).GetProperty("CityId");

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
            var viewModel = new AdvertSearchViewModel { CityId = testId };

            // Assert
            Assert.AreEqual(testId, viewModel.CityId);
        }
    }
}
