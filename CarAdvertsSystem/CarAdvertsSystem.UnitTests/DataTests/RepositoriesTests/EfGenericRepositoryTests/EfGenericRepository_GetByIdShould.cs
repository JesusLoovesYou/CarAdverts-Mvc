using NUnit.Framework;
using Moq;
using CarAdverts.Data.Contracts;
using System.Data.Entity;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using CarAdverts.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace CarAdvertsSystem.UnitTests.DataTests.RepositoriesTests.EfGenericRepositoryTests
{
    [TestFixture]
    public class EfGenericRepository_GetByIdShould
    {
        [Test]
        public void ReturnNull_WhenRequestedIdDoesNotExist()
        {
            // Arrange
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();

            var entities = new Mock<DbSet<MockDbModel>>();
            dbContext.Setup(c => c.Set<MockDbModel>()).Returns(entities.Object);

            var efGenericRepository = new EfGenericRepository<MockDbModel>(dbContext.Object);

            var fakeData = new HashSet<MockDbModel>()
            {
                new MockDbModel() { Id = 1 },
                new MockDbModel() { Id = 2 },
                new MockDbModel() { Id = 3 },
                new MockDbModel() { Id = 4 },
                new MockDbModel() { Id = 5 }
            };

            var fakeDataQueryable = fakeData.AsQueryable();

            entities.As<IQueryable>().Setup(e => e.GetEnumerator()).Returns(fakeDataQueryable.GetEnumerator());
            entities.As<IQueryable>().Setup(e => e.ElementType).Returns(fakeDataQueryable.ElementType);
            entities.As<IQueryable>().Setup(e => e.Expression).Returns(fakeDataQueryable.Expression);
            entities.As<IQueryable>().Setup(e => e.Provider).Returns(fakeDataQueryable.Provider);

            // Act
            var actualReturnedTEntity = efGenericRepository.GetById(0);

            // Assert
            Assert.That(actualReturnedTEntity, Is.Null);
        }
        
        [Test]
        public void ReturnCorrectTEntityInstance_WhenRequestedIdIsFound()
        {
            // Arrange
            var dbContext = new Mock<ICarAdvertsSystemDbContext>();

            var entities = new Mock<DbSet<MockDbModel>>();
            dbContext.Setup(c => c.Set<MockDbModel>()).Returns(entities.Object);

            var efGenericRepository = new EfGenericRepository<MockDbModel>(dbContext.Object);

            var matchingId = 4;

            var expectedReturnedTEntity = new MockDbModel() { Id = matchingId };

            var fakeData = new HashSet<MockDbModel>()
            {
                new MockDbModel() { Id = 1 },
                new MockDbModel() { Id = 2 },
                new MockDbModel() { Id = 3 },
                expectedReturnedTEntity,
                new MockDbModel() { Id = 5 }
            };

            var fakeDataQueryable = fakeData.AsQueryable();

            entities.As<IQueryable>().Setup(e => e.GetEnumerator()).Returns(fakeDataQueryable.GetEnumerator());
            entities.As<IQueryable>().Setup(e => e.ElementType).Returns(fakeDataQueryable.ElementType);
            entities.As<IQueryable>().Setup(e => e.Expression).Returns(fakeDataQueryable.Expression);
            entities.As<IQueryable>().Setup(e => e.Provider).Returns(fakeDataQueryable.Provider);

            var entityGuid = matchingId;

            // Act
            var actualReturnedTEntity = efGenericRepository.GetById(entityGuid);

            // Assert
            Assert.That(actualReturnedTEntity, Is.SameAs(expectedReturnedTEntity));
        }
    }
}