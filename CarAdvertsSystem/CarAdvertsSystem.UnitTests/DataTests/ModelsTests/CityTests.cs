using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.DataTests.ModelsTests
{
    [TestFixture]
    public class CitiesTests
    {
        // ---- Tests for constructur + adverts

        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange and Act
            var city = new City();

            // Assert
            Assert.IsInstanceOf<City>(city);
        }

        [Test]
        public void Constructor_ShouldInitializeAdvertCollectionCorrectly()
        {
            // Arrange
            var city = new City();

            // Act
            var advert = city.Adverts;

            // Assert
            Assert.That(advert, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }

        // ---- Tests for Id property

        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(City).GetProperty("Id");

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
            var city = new City() { Id = testId };

            // Assert
            Assert.AreEqual(testId, city.Id);
        }

        // ---- Tests for Name propery

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute, Is.Not.Null);
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CityNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CityNameMaxLength));
        }

        [TestCase("Sofia")]
        [TestCase("Varna")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange and Act
            var city = new City { Name = testName };

            //Assert
            Assert.AreEqual(city.Name, testName);
        }

        // ---- Tests for Adverts collection

        [TestCase(123)]
        [TestCase(12)]
        public void AdvertsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };

            // Act
            var city = new City() { Adverts = set };

            // Assert
            Assert.AreEqual(city.Adverts.First().Id, testId);
        }
    }
}
