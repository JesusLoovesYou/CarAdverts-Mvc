using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarAdverts.Web.Models
{
    [TestFixture]
    public class AdvertTests
    {
        // ---- Tests for Id property

        [Test]
        public void Id_ShouldHaveTheKeyAttribute()
        {
            // Arrange
            var keyAttributeProperty = typeof(Advert).GetProperty("Id");

            // Act
            var attribute = keyAttributeProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Id_ShouldGetAndSetIdCorrectly(int testId)
        {
            // Arrange and Act
            var advert = new Advert { Id = testId };

            // Assert
            Assert.AreEqual(testId, advert.Id);
        }

        // ---- Tests for Title property

        [Test]
        public void Title_ShouldHaveTheRequiredAttribute()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var requiredAttribute = titleProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_ShouldHaveTheCorrectMinLength()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var minLengthAttribute = titleProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertTitleMinLength));
        }

        [Test]
        public void Title_ShouldHaveTheCorrectMaxLength()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var maxLengthAttribute = titleProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertTitleMaxLength));
        }

        [TestCase("Best Scrap Car Brah!")]
        [TestCase("Best Hypercar Car Brah!")]
        public void Title_ShouldGetAndSetTitleDataCorrectly(string testTitle)
        {
            // Arrange and Act
            var advert = new Advert { Title = testTitle };

            // Assert
            Assert.AreEqual(testTitle, advert.Title);
        }

        // ---- Tests for IsDeleted property

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange and Act
            var advert = new Advert { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, advert.IsDeleted);
        }

        // ---- Tests for Year property

        [Test]
        public void Year_ShouldHaveRequiredAttribute()
        {
            // Arange
            var yearProp = typeof(Advert).GetProperty("Year");

            // Act
            var requiredAttribute = yearProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(1999)]
        [TestCase(2017)]
        public void Year_ShouldSetDataCorrectly(int testYear)
        {
            // Arrange and Act
            var advert = new Advert { Year = testYear };

            // Assert
            Assert.AreEqual(testYear, advert.Year);
        }

        // ---- Tests for Power property

        [Test]
        public void Power_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var powerProp = typeof(Advert).GetProperty("Power");

            // Act
            var requiredAttribute = powerProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(247)]
        [TestCase(1001)]
        public void Power_ShouldSetDataCorrectly(int testPower)
        {
            // Arrange and Act
            var advert = new Advert { Power = testPower };

            // Assert
            Assert.AreEqual(testPower, advert.Power);
        }

        // ---- Tests for DistanceCoverage property

        [Test]
        public void DistanceCoverage_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var distanceCoverageProp = typeof(Advert).GetProperty("DistanceCoverage");

            // Act
            var requiredAttribute = distanceCoverageProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(50000)]
        [TestCase(250000)]
        public void DistanceCoverage_ShouldSetDataCorrectly(int testDistanceCoverage)
        {
            // Arrange and Act
            var advert = new Advert { DistanceCoverage = testDistanceCoverage };

            // Assert
            Assert.AreEqual(testDistanceCoverage, advert.DistanceCoverage);
        }

        // ---- Tests for Description property

        [Test]
        public void Description_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var requiredAttribute = descriptionProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Description_ShouldHaveTheCorrectMinLength()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertDescriptionMinLength));
        }

        [Test]
        public void Description_ShouldHaveTheCorrectMaxLength()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.AdvertDescriptionMaxLength));
        }

        [TestCase("I Crashed My car Like 42 Times!!! Please Buy It!!!")]
        [TestCase("I Crashed My car Like 12312313 Times!!! Please Buy It!!!")]
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            // Arrange and Act
            var advert = new Advert { Description = testDescription };

            // Assert
            Assert.AreEqual(testDescription, advert.Description);
        }

        // ---- Tests for Constructor

        [Test]
        public void Constructor_ShouldInitializePictureCollectionCorreclty()
        {
            // Arrange
            var advert = new Advert();

            // Act
            var pictures = advert.Pictures;

            // Assert
            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<File>>());
        }

        [Test]
        public void Constructor_ShouldHaveParametlessConstructor()
        {
            // Arrange and Act
            var advert = new Advert();

            // Assert
            Assert.IsInstanceOf<Advert>(advert);
        }

        // ---- Tests for VehicleModel property

        [TestCase(15)]
        [TestCase(20)]
        public void VehicleModelId_ShouldGetAndSetDataCorrectly(int testVehicleModelId)
        {
            // Arrange and Act
            var advert = new Advert() { VehicleModelId = testVehicleModelId };

            // Assert
            Assert.AreEqual(advert.VehicleModelId, testVehicleModelId);
        }

        [TestCase("Model X")]
        [TestCase("La Ferrari")]
        public void VehicleModel_ShouldGetAndSetDataCorrectly(string testVehicleModelName)
        {
            // Arrange
            var vehicleModel = new VehicleModel { Name = testVehicleModelName };

            // Act
            var advert = new Advert() { VehicleModel = vehicleModel };

            // Assert
            Assert.AreEqual(advert.VehicleModel.Name, testVehicleModelName);
        }

        // ---- Tests for CitiyId property

        [TestCase(15)]
        [TestCase(20)]
        public void CityId_ShouldGetAndSetDataCorrectly(int testCityId)
        {
            // Arrange and Act
            var advert = new Advert() { CityId = testCityId };

            // Assert
            Assert.AreEqual(advert.CityId, testCityId);
        }

        // ---- Tests for City property

        [TestCase("Veliko Turnovo")]
        [TestCase("Sofia")]
        public void City_ShouldGetAndSetDataCorreclty(string testCityName)
        {
            // Arrange
            var city = new City { Name = testCityName };

            // Act
            var advert = new Advert { City = city };

            // Assert
            Assert.AreEqual(advert.City.Name, testCityName);
        }

        // ---- Tests for UserId property

        [TestCase("191983391239jskd-asdnbjasdnj-22")]
        [TestCase("asdjasdj9i1231-123ju1jsad")]
        public void UserId_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange and Act
            var advert = new Advert() { UserId = testUserId };

            // Assert
            Assert.AreEqual(advert.UserId, testUserId);
        }

        // ---- Tests for IsDeleted property

        [TestCase("chuk@abv.bg")]
        [TestCase("tuturutka@yahoo.com")]
        public void User_ShouldGetAndSetDataCorreclty(string testUserEmail)
        {
            // Arrange
            var user = new User { Email = testUserEmail };

            // Act
            var advert = new Advert { User = user };

            // Assert
            Assert.AreEqual(advert.User.Email, testUserEmail);
        }

        // ---- Tests for Picture property

        [TestCase(123)]
        [TestCase(12)]
        public void PictureCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange
            var picture = new File() { Id = testId };
            var set = new HashSet<File> { picture };

            // Act
            var manufacturer = new Advert() { Pictures = set };

            // Assert
            Assert.AreEqual(manufacturer.Pictures.First().Id, testId);
        }

        // ---- Tests for Price property 

        [Test]
        public void Price_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Price");

            // Act
            var requiredAttribute = descriptionProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(123.5d)]
        [TestCase(12d)]
        public void Price_ShouldGetAndSetDataCorrectly(decimal price)
        {
            // Arrange
            var advert = new Advert() { Price = price };

            // Act and Assert
            Assert.AreEqual(advert.Price, price);
        }
    }
}