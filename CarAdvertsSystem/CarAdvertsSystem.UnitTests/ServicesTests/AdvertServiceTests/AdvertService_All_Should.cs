using NUnit.Framework;
using Moq;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using CarAdverts.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_All_Should
    {
        [Test]
        public void InvokeEfProviderAdvertsMethod_All_Once()
        {
            // Arrange
            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.All();

            // Assert
            mockedAdvertRepository.Verify(p => p.All(), Times.Once);
        }
        
        [Test]
        public void ReturnCorrectAdverts()
        {
            // Arrange
            var expectedAdvert = new List<Advert>()
            {
                new Advert() { Id = 1, Title = "Advert 1" },
                new Advert() { Id = 2, Title = "Advert 2"  },
                new Advert() { Id = 3, Title = "Advert 3"  }
            }.AsQueryable();

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            mockedAdvertRepository.Setup(x => x.All()).Returns(expectedAdvert);
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            var result = advertService.All();

            // Assert
            Assert.AreEqual(result, expectedAdvert);
        }



    }
}
