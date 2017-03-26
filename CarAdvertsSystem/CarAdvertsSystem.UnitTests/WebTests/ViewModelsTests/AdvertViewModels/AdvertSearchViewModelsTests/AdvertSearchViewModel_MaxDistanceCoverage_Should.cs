using System.ComponentModel.DataAnnotations;
using System.Linq;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertSearchViewModelsTests
{
    [TestFixture]
    public class AdvertSearchViewModel_MaxDistanceCoverage_Should
    {
        [Test]
        public void HaveTheDisplayAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertSearchViewModel).GetProperty("MaxDistanceCoverage");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(DisplayAttribute), true)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(1000)]
        public void GetAndSetDataCorrectly(int test)
        {
            // Arrange and Act
            var viewModel = new AdvertSearchViewModel { MaxDistanceCoverage = test };

            // Assert
            Assert.AreEqual(test, viewModel.MaxDistanceCoverage);
        }
    }
}
