using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_Title_Should
    {
        [Test]
        public void HaveTheAllolHtmlAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("Title");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(AllowHtmlAttribute), true)
                .Cast<AllowHtmlAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void HaveTheDataTypeAttribute()
        {
            // Arrange
            var allowHtmlattribute = typeof(AdvertInputViewModel).GetProperty("Title");

            // Act
            var attribute = allowHtmlattribute.GetCustomAttributes(typeof(DataType), true)
                .Cast<DataType>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("test")]
        public void GetAndSetDataCorrectly(string testTitle)
        {
            // Arrange and Act
            var viewModel = new AdvertInputViewModel { Title = testTitle };

            // Assert
            Assert.AreEqual(testTitle, viewModel.Title);
        }


    }
}
