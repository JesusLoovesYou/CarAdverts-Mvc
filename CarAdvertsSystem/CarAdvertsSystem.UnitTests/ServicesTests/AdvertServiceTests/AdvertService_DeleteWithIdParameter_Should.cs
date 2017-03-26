using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Services;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_DeleteWithIdParameter_Should
    {
        [Test]
        public void InvokeEfDataProviderAdvertMethod_Delete_Once()
        {
            // Arrange
            int id = 1;

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Delete(id);

            // Assert
            mockedAdvertRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void InvokeEfDataProviderMethod_SaveChanges_Once()
        {
            // Arrange
            int id = 1;

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.Delete(id);

            // Assert
            mockedEfProvider.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
