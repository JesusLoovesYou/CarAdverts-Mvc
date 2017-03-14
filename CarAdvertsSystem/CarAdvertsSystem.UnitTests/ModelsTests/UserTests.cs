using CarAdverts.Common.Constants;
using CarAdverts.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarAdvertsSystem.UnitTests.ModelsTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldHaveParametlessConstructor()
        {
            // Arrange and Act
            var user = new User();
            
            // Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void Constructor_ShouldInitializeAdvertCollectionCorreclty()
        {
            // Arrange
            var user = new User();

            // Act
            var adverts = user.Adverts;

            // Assert
            Assert.That(adverts, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }

        [Test]
        public void FirstName_ShouldHaveTheCorrectMinLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserFirstNameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveTheCorrectMaxLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("FirstName");

            // Act
            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserFirstNameMaxLength));
        }

        [TestCase("Vasil")]
        [TestCase("Ivan")]
        public void FirstName_ShouldSetTitleDataCorrectly(string testFirstName)
        {
            // Arrange and Act
            var user = new User { FirstName = testFirstName };

            // Assert
            Assert.AreEqual(testFirstName, user.FirstName);
        }

        [Test]
        public void LastName_ShouldHaveTheCorrectMinLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("LastName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserLastNameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveTheCorrectMaxLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("LastName");

            // Act
            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.UserLastNameMaxLength));
        }

        [TestCase("Penev")]
        [TestCase("Angelov")]
        public void LastName_ShouldSetTitleDataCorrectly(string testLastName)
        {
            // Arrange and Act
            var user = new User { LastName = testLastName };

            // Assert
            Assert.AreEqual(testLastName, user.LastName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange and Act
            var user = new User { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, user.IsDeleted);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void AdvertCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };

            // Act
            var user = new User() { Adverts = set };

            // Assert
            Assert.AreEqual(user.Adverts.First().Id, testId);
        }
    }
}
