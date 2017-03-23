using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CarAdverts.Models;
using System.Web;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using CarAdverts.Data.Repositories.EfRepository.Contracts;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    [TestFixture]
    public class AdvertService_CreateAdvert_Should
    {
        [Test]
        public void ThrowArgumentNullExeption_IfAdvertParameterIsNull()
        {
            // Arrange
            Advert advert = null;
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act and Assert
            Assert.That(() => advertService.AddUploadedFilesToAdvert(advert, files),
                Throws.ArgumentNullException);
        }

        /// <summary>
        /// Invoke AddUploadedFilesToAdvert ............... I Should Add this test
        /// </summary>

            
        [Test]
        public void InvokeEfDeletableRepositoryMethod_Add_Once_IfAdvertParameterIsNotNull()
        {
            // Arrange
            Advert advert = new Advert { Id = 1 };
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.CreateAdvert(advert, files);

            // Assert
            mockedAdvertRepository.Verify(r => r.Add(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void InvokeProviderMethod_SaveChanges_Once_IfAdvertParameterIsNotNull()
        {
            // Arrange
            Advert advert = new Advert { Id = 1 };
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedAdvertRepository = new Mock<IEfDeletableRepository<Advert>>();

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Adverts).Returns(mockedAdvertRepository.Object);

            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act
            advertService.CreateAdvert(advert, files);

            // Assert
            mockedEfProvider.Verify(p => p.SaveChanges(), Times.Once);
        }


    }
}
