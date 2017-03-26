using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_Description_Should
    {
        [Test]
        public void HaveTheAllolHtmlAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("Description");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(AllowHtmlAttribute), true)
                .Cast<AllowHtmlAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void HaveThDataTypeAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("Description");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(DataType), true)
                .Cast<DataType>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("description")]
        public void GetAndSetDataCorrectly(string testDescr)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { Description = testDescr };

            // Assert
            Assert.AreEqual(testDescr, viewModel.Description);
        }
    }
}
