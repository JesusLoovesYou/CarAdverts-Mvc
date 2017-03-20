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
    public class EfGenericRepository_DeleteWithIntegerIdParameter_Should
    {
        [Test]
        public void CallMethod_GetByIdOnce()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            mockedDbContext.Setup(set => set.Set<IAdvert>()).Returns(mockedSet.Object);
            var repository = new EfGenericRepository<IAdvert>(mockedDbContext.Object);
            int id = 1;

            // Act
            repository.Delete(id);

            // Assert
            //Assert.That(() => repository.GetById(1), Times.Once());
            
        }

        // TODO: if entity != null call method Delete(entity)
        // TODO: if entity == null DONT call method Delete(entity)


    }
}
