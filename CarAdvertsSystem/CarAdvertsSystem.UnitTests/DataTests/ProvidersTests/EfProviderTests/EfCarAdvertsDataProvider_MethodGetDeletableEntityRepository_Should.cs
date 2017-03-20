using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models;
using CarAdverts.Models.Contracts;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.ProvidersTests.EfProviderTests
{
    [TestFixture]
    public class EfCarAdvertsDataProvider_MethodGetDeletableEntityRepository_Should
    {
        [Test]
        public void ReturnCorrectInstanceOfIEfDeletableRepositoryOfAdverts()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Adverts;

            // Assert
            Assert.IsInstanceOf<EfDeletableRepository<Advert>>(result);
        }
    }
}
