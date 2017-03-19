using CarAdverts.Data.Contracts;
using CarAdverts.Models.Contracts;
using Moq;
using NUnit.Framework;
using System.Data.Entity;
using CarAdverts.Data.Repositories.EfRepository.Base;

namespace CarAdvertsSystem.UnitTests.DataTests.RepositoriesTests.EfGenericRepositoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        //[Test]
        //public void ConstructorShould_ReturnNewInstanceOfGenericRepo_IfParamsAreValid()
        //{
        //    // Arrange
        //    var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
        //    var mockedModel = new Mock<DbSet<IAdvert>>();
        //    mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

        //    // Act
        //    var repository = new EfGenericRepository<IAdvert>(mockedContext.Object);

        //    // Assert
        //    Assert.That(repository, Is.Not.Null);
        //}

        //[Test]
        //public void ConstructorShould_ShouldThrowArgumentNullException_IfPassedContextIsNullWithAppropriateMessage()
        //{
        //    // Arrange and Act
        //    ICarAdvertsSystemDbContext contextThatIsNull = null;

        //    // Assert
        //    Assert.That(() => new EfGenericRepository<IAdvert>(contextThatIsNull),
        //        Throws.ArgumentNullException.With.Message.Contains
        //        (nameof(ICarAdvertsSystemDbContext)));
        //}

        //[Test]
        //public void ConstructorShould_ReturnCorrectContext_IfValidParamsPassed()
        //{
        //    // Arrange
        //    var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
        //    var mockedModel = new Mock<DbSet<IAdvert>>();
        //    mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);

        //    // Act
        //    var repository = new EfGenericRepository<IAdvert>(mockedContext.Object);

        //    // Assert
        //    Assert.That(repository.Context, Is.Not.Null);
        //    Assert.That(repository.Context, Is.EqualTo(mockedContext.Object));
        //}
    }
}
