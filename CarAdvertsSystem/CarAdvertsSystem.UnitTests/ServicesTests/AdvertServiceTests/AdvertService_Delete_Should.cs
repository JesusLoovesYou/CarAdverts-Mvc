using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_Delete_Should
    {
        // Throw if advert parameter is null
        [Test]
        public void ThrowArgumentNullException_WhenIdParameterIsNull()
        {
            // Arrange
            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);
            Advert advert = null;
            
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => advertService.Delete(advert));
        }

        // Call ef provider adverts method delete
        [Test]
        public void InvokeEfDataProviderAdvertMethod_Delete_Once_WhenIdParameterIsNotNull()
        {
            // Arrange
            Advert advert = new Advert() { Id = 1 };

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Delete(advert);

            // Assert
            mockedAdvertRepository.Verify(x => x.Delete(It.IsAny<Advert>()), Times.Once);
        }

        // Call ef provider save changes
        [Test]
        public void InvokeEfDataProviderMethod_SaveChanges_Once_WhenIdParameterIsNotNull()
        {
            // Arrange
            Advert advert = new Advert() { Id = 1 };

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            //mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Delete(advert);

            // Assert
            mockedEfProvider.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
