using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;
using CarAdverts.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.VehicleModelServiceTests
{
    [TestFixture()]
    public class VehicleModel_All_Should
    {
        [Test]
        public void InvokeEfProviderCitiesMethod_All_Once()
        {
            // Arrange
            var mockedVehicleModelRepository = new Mock<IEfDeletableRepository<VehicleModel>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.VehicleModels).Returns(mockedVehicleModelRepository.Object);

            var vehicleModelService = new VehicleModelService(mockedEfProvider.Object);

            // Act
            var result = vehicleModelService.All();

            // Assert
            mockedVehicleModelRepository.Verify(p => p.All(), Times.Once);
        }

        [Test]
        public void ReturnCorrectCities()
        {
            // Arrange
            var expectedModels = new List<VehicleModel>()
            {
                new VehicleModel() { Id = 1, Name = "Test 1" },
                new VehicleModel() { Id = 2, Name = "Test 2"  },
                new VehicleModel() { Id = 3, Name = "Test 3"  }
            }.AsQueryable();

            var mockedVehicleModelRepository = new Mock<IEfGenericRepository<VehicleModel>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            mockedVehicleModelRepository.Setup(x => x.All()).Returns(expectedModels);
            mockedEfProvider.Setup(p => p.VehicleModels).Returns(mockedVehicleModelRepository.Object);

            var vehicleModelService = new VehicleModelService(mockedEfProvider.Object);

            // Act
            var result = vehicleModelService.All();

            // Assert
            Assert.AreEqual(result, expectedModels);
        }
    }
}
