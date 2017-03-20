using System.ComponentModel.DataAnnotations;
using System.Linq;
using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.DataTests.ModelsTests
{
    [TestFixture]
    public class FileTests
    {
        // ---- Tests for Id property

        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(File).GetProperty("Id");

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
            var picture = new File() { Id = testId };

            //Assert
            Assert.AreEqual(testId, picture.Id);
        }

        // ---- Tests for Name property

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(File).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }
        
        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(File).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.FileNameMaxLength));
        }

        [TestCase("1.jpg")]
        [TestCase("2.jpg")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange and Act
            var vehicleModel = new File() { Name = testName };

            //Assert
            Assert.AreEqual(vehicleModel.Name, testName);
        }

        // ---- Tests for ContentType property

        [Test]
        public void ContentType_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var contentTypeProperty = typeof(File).GetProperty("ContentType");

            // Act
            var requiredAttribute = contentTypeProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void ContentType_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var contentTypeProperty = typeof(File).GetProperty("ContentType");

            // Act
            var maxLengthAttribute = contentTypeProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.FileContentTypeMaxLength));
        }

        [TestCase("type 1")]
        [TestCase("type 2")]
        public void ContentType_ShouldGetAndSetDataCorrectly(string testContentType)
        {
            // Arrange and Act
            var file = new File() { ContentType = testContentType };

            //Assert
            Assert.AreEqual(file.ContentType, testContentType);
        }

        // ---- Tests for Content property

        [Test]
        public void Content_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var contentTypeProperty = typeof(File).GetProperty("Content");

            // Act
            var requiredAttribute = contentTypeProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Content_ShouldGetAndSetDataCorrectly()
        {
            byte[] byteArray = new byte[5];

            // Arrange and Act
            var file = new File() { Content = byteArray };

            //Assert
            Assert.AreEqual(file.Content, byteArray);
            Assert.AreEqual(file.Content.Length, byteArray.Length);
        }

        // ---- Tests for FileType property

        [Test]
        public void FileType_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var contentTypeProperty = typeof(File).GetProperty("FileType");

            // Act
            var requiredAttribute = contentTypeProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void FileType_ShouldGetAndSetDataCorrectly()
        {
            var testType = FileType.Avatar;

            // Arrange and Act
            var file = new File() { FileType = testType };

            //Assert
            Assert.AreEqual(file.FileType, testType);
        }

        // ---- Tests for AdvertId property

        [TestCase(15)]
        [TestCase(20)]
        public void AdvertId_ShouldGetAndSetDataCorrectly(int testAdvertId)
        {
            // Arrange and Act
            var picture = new File() { AdvertId = testAdvertId };

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
            var picture = new File() { Advert = advert };

            //Assert
            Assert.AreEqual(picture.Advert.Title, testAdvertTitle);
        }
    }
}
