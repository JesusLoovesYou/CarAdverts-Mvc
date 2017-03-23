using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.FileControllerTests
{
    [TestFixture]
    public class FileController_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFileServiceParameterIsNull()
        {
            // Arrange
            IFileService fileService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FileController(fileService));
        }

        [Test]
        public void CreateInstanceOfFileService_WhenFileServiceParameterIsNotNull()
        {
            // Arrange
            var fileService = new Mock<IFileService>();

            // Act
            var fileController = new FileController(fileService.Object);

            // Act and Assert
            Assert.That(fileController, Is.Not.Null);
            Assert.IsInstanceOf<FileController>(fileController);
        }
    }
}
