using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models.Contracts;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.ProvidersTests.EfProviderTests
{
    [TestFixture]
    public class EfCarAdvertsDataProvider_ConstructorShould
    {
        [Test]
        public void ConstructorShould_ShouldThrowArgumentNullExceptionWithAppropriateMessage_IfPassedContextIsNull()
        {
            // Arrange
            ICarAdvertsSystemDbContext contextThatIsNull = null;

            // Act and Assert
            Assert.That(() => new EfCarAdvertsDataProvider(contextThatIsNull),
                Throws.ArgumentNullException.With.Message.Contains
                (nameof(ICarAdvertsSystemDbContext)));
        }

        [Test]
        public void ConstructorShould_ReturnNewInstanceOfEfProvider_IfParamsAreValid()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);

            // Assert
            Assert.That(provider, Is.Not.Null);
        }

        [Test]
        public void ConstructorShould_ReturnCorrectContext_IfValidParamsPassed()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);

            // Assert
            Assert.That(provider.Context, Is.Not.Null);
            Assert.That(provider.Context, Is.EqualTo(mockedContext.Object));
        }
    }
}

