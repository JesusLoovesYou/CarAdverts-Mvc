using System;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_Update_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertParameterIsNull()
        {
            // Arrange
            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);
            Advert advert = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => advertService.Update(advert));
        }

        [Test]
        public void InvokeEfDataProviderAdvertMethod_Update_Once_WhenAdvertParameterIsNotNull()
        {
            // Arrange
            var advert = new Advert() { Id = 1 };

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Update(advert);

            // Assert
            mockedAdvertRepository.Verify(x => x.Update(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void InvokeEfDataProviderMethod_SaveChanges_Once()
        {
            // Arrange
            var advert = new Advert() { Id = 1 };

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Update(advert);

            // Assert
            mockedEfProvider.Verify(x => x.SaveChanges(), Times.Once);
        }


    }
}
