using NUnit.Framework;
using Moq;
using CarAdverts.Data.Contracts;
using System.Data.Entity;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using System.Collections.Generic;
using System.Linq;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models.Contracts;

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
        public void ReturnNull_WhenRequestedIdIsNull()
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
            var actualReturnedTEntity = efGenericRepository.GetById(null);

            // Assert
            Assert.That(actualReturnedTEntity, Is.Null);
        }
        
        [TestCase(15)]
        [TestCase(2)]
        public void ReturnCorrectResult_WhenParameterIsValid(int validId)
        {
            // Arrange 
            var mockedDbSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarAdvertsSystemDbContext>();

            var fakeAdvert = new Mock<IAdvert>();
            fakeAdvert.SetupSet(f => f.Id = validId);
            
            mockedDbContext.Setup(mock => mock.Set<IAdvert>()).Returns(mockedDbSet.Object);
            var repository = new EfGenericRepository<IAdvert>(mockedDbContext.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAdvert.Object);

            // Act and Assert
            Assert.That(repository.GetById(validId), Is.Not.Null);
            Assert.AreEqual(repository.GetById(validId), fakeAdvert.Object);
        }

        [TestCase(1)]
        [TestCase(null)]
        public void InvockeDbSet_MethodFindOnce(int? id)
        {
            // Arrange 
            var mockedDbSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarAdvertsSystemDbContext>();
            
            mockedDbContext.Setup(mock => mock.Set<IAdvert>()).Returns(mockedDbSet.Object);
            var repository = new EfGenericRepository<IAdvert>(mockedDbContext.Object);

            repository.GetById(id);

            // Assert
            mockedDbSet.Verify(x => x.Find(It.IsAny<int?>()), Times.Once);
        }
    }
}