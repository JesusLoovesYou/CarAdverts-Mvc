using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.ProvidersTests.EfProviderTests
{
    [TestFixture]
    public class EfCarAdvertsDataProvider_SaveChangesShould
    {
        [Test]
        public void InvockeFromContext_MethodSaveChanges()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            provider.SaveChanges();

            // Assert
            mockedContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
