using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models.Contracts;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.RepositoriesTests.EfGenericRepositoryTests
{
    [TestFixture]
    public class EfGenericRepository_AllShould
    {
        [Test]
        public void All_Should_ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedSet = new Mock<DbSet<MockDbModel>>();
            mockedDbContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedSet.Object);

            var repository = new EfGenericRepository<MockDbModel>(mockedDbContext.Object);

            // Act
            var allEntities = repository.All();

            // Assert
            Assert.NotNull(allEntities);
            Assert.IsInstanceOf(typeof(DbSet<MockDbModel>), allEntities);
            Assert.AreSame(allEntities, repository.DbSet);
        }
    }
}
