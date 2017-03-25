using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_GetById_Should
    {
        [Test]
        public void ReturnNull_IfParameterIdIsNull()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var advertService = new AdvertService(mockedEfProvider.Object);
            var result = advertService.GetById(null);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void InvoceEfProviderAdvertMethod_GetById_Once_IfParameterIdIsNotNull()
        {
            // Arrange
            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            // Act
            var advertService = new AdvertService(mockedEfProvider.Object);
            var result = advertService.GetById(1);

            // Assert
            mockedAdvertRepository.Verify(p => p.GetById(It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void InvoceEfProviderAdvertMethod_GetById_Never_IfParameterIdIsNull()
        {
            // Arrange
            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            // Act
            var advertService = new AdvertService(mockedEfProvider.Object);
            var result = advertService.GetById(null);

            // Assert
            mockedAdvertRepository.Verify(p => p.GetById(It.IsAny<int?>()), Times.Never);
        }

        [Test]
        public void ReturnCorrectFile_IfParameterIdIsValid_AndThereIsFileWithIdEqualOfParamId()
        {
            // Arrange
            var expectedAdvert = new Advert() { Id = 1 };

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);
            mockedAdvertRepository.Setup(f => f.GetById(It.IsAny<int>())).Returns(expectedAdvert);

            // Act
            var advertService = new AdvertService(mockedEfProvider.Object);
            var result = advertService.GetById(1);

            // Assert
            Assert.AreEqual(result, expectedAdvert);
        }
    }
}
