using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Contracts;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Base;
using CarAdverts.Models;
using CarAdverts.Models.Contracts;
using CarAdvertsSystem.UnitTests.DataTests.Mocks;
using NUnit.Framework;
using Moq;

namespace CarAdvertsSystem.UnitTests.DataTests.ProvidersTests.EfProviderTests
{
    [TestFixture]
    public class EfCarAdvertsDataProvider_MethodGetEfGenericRepository_Should
    {
        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfManufacturers()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Manufacturers;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<Manufacturer>>(result);
        }

        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfVehicleModels()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.VehicleModels;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<VehicleModel>>(result);
        }

        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfCategories()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Categories;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<Category>>(result);
        }

        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfCities()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Cities;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<City>>(result);
        }

        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfFiles()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Files;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<File>>(result);
        }

        [Test]
        public void ReturnCorrectInstanceOfIEfGenericRepository_OfUsers()
        {
            // Arrange
            var mockedContext = new Mock<ICarAdvertsSystemDbContext>();
            var mockedModel = new Mock<DbSet<MockDbModel>>();
            mockedContext.Setup(x => x.Set<MockDbModel>()).Returns(mockedModel.Object);

            // Act
            var provider = new EfCarAdvertsDataProvider(mockedContext.Object);
            var result = provider.Users;

            // Assert
            Assert.IsInstanceOf<EfGenericRepository<User>>(result);
        }
    }
}
