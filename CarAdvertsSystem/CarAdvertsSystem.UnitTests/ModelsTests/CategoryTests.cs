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
    public class CategoryTests
    {
        // --- Test for constructor + vehicleModel

        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void Constructor_ShouldInitializeVehicleModelsCollectionCorrectly()
        {
            // Arrange
            var category = new Category();

            // Act
            var vehicleModel = category.VethicleModels;

            // Assert
            Assert.That(vehicleModel, Is.Not.Null.And.InstanceOf<HashSet<VehicleModel>>());
        }

        // ---- Test for Id propery

        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Category).GetProperty("Id");

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
            // Arrange & Act
            var category = new Category() { Id = testId };

            //Assert
            Assert.AreEqual(testId, category.Id);
        }


        // ---- Tests for Name property

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

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
            var nameProperty = typeof(Category).GetProperty("Name");

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
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CategoryNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.CategoryNameMaxLength));
        }

        [TestCase("Car")]
        [TestCase("Bus")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var category = new Category() { Name = testName };

            //Assert
            Assert.AreEqual(category.Name, testName);
        }

        // ---- Tests for VehicleModels collection

        [TestCase(123)]
        [TestCase(12)]
        public void VehicleModelsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var vehicleModel = new VehicleModel() { Id = testId };
            var set = new HashSet<VehicleModel> { vehicleModel };

            var category = new Category() { VethicleModels = set };

            Assert.AreEqual(category.VethicleModels.First().Id, testId);
        }
    }
}
