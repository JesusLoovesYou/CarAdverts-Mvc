using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarAdvertsSystem.UnitTests.ModelsTests
{
    [TestFixture]
    public class ManufacturerTests
    {
        // ----- Tests for constuctur

        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange and Act
            var manufacturer = new Manufacturer();

            // Assert
            Assert.IsInstanceOf<Manufacturer>(manufacturer);
        }

        [Test]
        public void Constructor_ShouldInitializeVehicleModelCollectionCorrectly()
        {
            // Arrange
            var manufacturer = new Manufacturer();

            // Act
            var vehicleModel = manufacturer.Models;

            // Assert
            Assert.That(vehicleModel, Is.Not.Null.And.InstanceOf<HashSet<VehicleModel>>());
        }

        // ----- Tests for Id property

        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Manufacturer).GetProperty("Id");

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
            var manufacturer = new Manufacturer { Id = testId };

            //Assert
            Assert.AreEqual(testId, manufacturer.Id);
        }

        // Tests for Name property

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

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
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ManufacturerNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.ManufacturerNameMaxLength));
        }

        [TestCase("Audi")]
        [TestCase("BMV")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var manufacturer = new Manufacturer { Name = testName };

            //Assert
            Assert.AreEqual(manufacturer.Name, testName);
        }

        // ----- Tests for VechicleModel collection

        [TestCase(123)]
        [TestCase(12)]
        public void VehicleModelCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange
            var vehicleModel = new VehicleModel() { Id = testId };
            var set = new HashSet<VehicleModel> { vehicleModel };

            // Act
            var manufacturer = new Manufacturer() { Models = set };

            // Assert
            Assert.AreEqual(manufacturer.Models.First().Id, testId);
        }
    }
}
