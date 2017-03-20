using NUnit.Framework;
using Moq;
using CarAdverts.Data.Contracts;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;
using CarAdverts.Data.Repositories.EfRepository.Base;

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

        //[Test]
        //public void InvokeIDbSet_AddMethodOnceWithCorrectParameter()
        //{
        //    // Arrange
        //    var dbContext = new Mock<ICarAdvertsSystemDbContext>();
        //    var dbSet = new Mock<DbSet<MockDbModel>>();
        //    dbSet.SetupAllProperties();

        //    var fakeEntry = (DbEntityEntry<MockDbModel>)FormatterServices.GetSafeUninitializedObject(typeof(DbEntityEntry<MockDbModel>));

        //    dbContext.Setup(c => c.Set<MockDbModel>()).Returns(dbSet.Object);
        //    dbContext.Setup(x => x.Entry(It.IsAny<MockDbModel>())).Returns(fakeEntry);

        //    var genericRepository = new EfGenericRepository<MockDbModel>(dbContext.Object);

        //    MockDbModel entity = new MockDbModel();

        //    // Act
        //    genericRepository.Add(entity);

        //    // Assert
        //    dbContext.Verify(x => x.Entry(dbContext.Object), Times.AtLeastOnce);
        //}
    }
}
