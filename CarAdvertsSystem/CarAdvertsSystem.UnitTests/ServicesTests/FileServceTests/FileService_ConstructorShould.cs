using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;

namespace CarAdvertsSystem.UnitTests.ServicesTests.FileServceTests
{
    [TestFixture]
    public class FileService_ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExeption_IfParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efDataProvider = null;
            
            // Act and Assert
            Assert.That(() => new FileService(efDataProvider),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorShould_ReturnNewInstanceOfFileService_IfParameterIsValid()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var fileService = new FileService(mockedEfProvider.Object);

            // Assert
            Assert.That(fileService, Is.Not.Null);
        }
    }
}
