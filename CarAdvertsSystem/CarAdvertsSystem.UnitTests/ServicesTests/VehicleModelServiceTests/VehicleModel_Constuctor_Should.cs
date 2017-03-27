using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Moq;

namespace CarAdvertsSystem.UnitTests.ServicesTests.VehicleModelServiceTests
{
    [TestFixture]
    public class VehicleModel_Constuctor_Should
    {
        [Test]
        public void ThrowArgumentNullExeption_IfParameterIsNull()
        {
            // Arrange
            IEfCarAdvertsDataProvider efDataProvider = null;

            // Act and Assert
            Assert.That(() => new VehicleModelService(efDataProvider),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorShould_ReturnNewInstanceOfVehicleModel_IfParameterIsValid()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var vehicleModel = new VehicleModelService(mockedEfProvider.Object);

            // Assert
            Assert.That(vehicleModel, Is.Not.Null);
        }
    }
}
