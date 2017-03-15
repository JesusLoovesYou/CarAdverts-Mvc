using NUnit.Framework;
using Moq;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.Base;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using System;
using System.Data.Entity;

namespace CarAdvertsSystem.UnitTests.DataTests.RepositoriesTests.EfGenericRepositoryTests
{
    [TestFixture]
    public class EfGenericRepository_AddShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhitCorrectMessage_WhenEntityParameterIsNull()
        {
            // Arrange
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();

            var efGenericRepository = new EfGenericRepository<MockDbModel>(dbContext.Object);

            MockDbModel entity = null;

            // Act and Assert
            Assert.That(
                () => efGenericRepository.Add(entity), 
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(entity)));
        }

        [Test]
        public void InvokeIDbSet_AddMethodOnceWithCorrectParameter()
        {
            // Arrange
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();

            var dbSet = new Mock<DbSet<MockDbModel>>();
            dbContext.Setup(c => c.Set<MockDbModel>()).Returns(dbSet.Object);

            var genericRepository = new EfGenericRepository<MockDbModel>(dbContext.Object);

            MockDbModel entity = new MockDbModel();

            // Act
            genericRepository.Add(entity);

            // Assert
            dbSet.Verify(s => s.Add(entity), Times.Once);
        }
    }
}
