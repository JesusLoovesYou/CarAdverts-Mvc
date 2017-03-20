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
    public class EfCarAdvertsDataProvider_DisposedWithParameters_Should
    {
        [Test]
        public void InvockeFromContext_MethodDispose_Once_IfParameterIsTrue()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            provider.Dispose(true);

            // Assert
            mockedContext.Verify(c => c.Dispose(), Times.Once);
        }

        [Test]
        public void InvockeFromContext_MethodDispose_Never_IfParameterIsTrue()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            provider.Dispose(false);

            // Assert
            mockedContext.Verify(c => c.Dispose(), Times.Never);
        }


    }
}
