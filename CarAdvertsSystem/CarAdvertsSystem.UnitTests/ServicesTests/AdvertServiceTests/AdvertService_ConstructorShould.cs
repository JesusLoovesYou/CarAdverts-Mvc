using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExeption_IfParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efDataProvider = null;

            // Act and Assert
            Assert.That(() => new AdvertService(efDataProvider),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorShould_ReturnNewInstanceOfAdvertService_IfParameterIsValid()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var advertService = new AdvertService(mockedEfProvider.Object);

            // Assert
            Assert.That(advertService, Is.Not.Null);
        }
    }
}
