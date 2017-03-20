using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models.Contracts;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.RepositoriesTests.EfGenericRepositoryTests
{
    [TestFixture]
    public class EfGenericRepository_DeleteWithTEntityParameter_Should
    {
        [Test]
        public void ThrowNullReferenceExceptionWhithCorrectMessage_WhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            mockedDbContext.Setup(set => set.Set<IAdvert>()).Returns(mockedSet.Object);
            var repository = new EfGenericRepository<IAdvert>(mockedDbContext.Object);
            IAdvert entity = null;
            
            // Act and Assert
            Assert.That(() => repository.Delete(entity),
                Throws.ArgumentNullException.With.Message.Contains
                (nameof(entity)));
        }

        // TODO: Check entrystate
        // TODO: Set entristate to delted   or
        // TODO: Call dbSet methods Attach and Remove once
    }
}
