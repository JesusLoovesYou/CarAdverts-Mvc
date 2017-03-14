using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarAdvertsSystem.UnitTests.ModelsTests
{
    [TestFixture]
    public class PictureTests
    {
        // ---- Tests for Id property

        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Picture).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange and Act
            var picture = new Picture() { Id = testId };

            //Assert
            Assert.AreEqual(testId, picture.Id);
        }

        // ---- Tests for Name property

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Picture).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Picture).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PictureNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Picture).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.PictureNameMaxLength));
        }

        [TestCase("1.jpg")]
        [TestCase("2.jpg")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange and Act
            var vehicleModel = new Picture() { Name = testName };

            //Assert
            Assert.AreEqual(vehicleModel.Name, testName);
        }

        // ---- Tests for AdvertId property

        [TestCase(15)]
        [TestCase(20)]
        public void AdvertId_ShouldGetAndSetDataCorrectly(int testAdvertId)
        {
            // Arrange and Act
            var picture = new Picture() { AdvertId = testAdvertId };

            //Assert
            Assert.AreEqual(picture.AdvertId, testAdvertId);
        }

        // ---- Tests for Advert property

        [TestCase("Audi A4")]
        [TestCase("Fiat Punto JTD 1.9")]
        public void Advert_ShouldGetAndSetDataCorrectly(string testAdvertTitle)
        {
            // Arrange and Act         
            var advert = new Advert() { Title = testAdvertTitle };
            var picture = new Picture() { Advert = advert };

            //Assert
            Assert.AreEqual(picture.Advert.Title, testAdvertTitle);
        }
    }
}
