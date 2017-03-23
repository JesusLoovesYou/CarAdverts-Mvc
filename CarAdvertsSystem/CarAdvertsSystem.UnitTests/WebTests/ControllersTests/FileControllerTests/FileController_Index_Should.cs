using NUnit.Framework;
using Moq;
using CarAdverts.Services.Contracts;
using CarAdverts.Web.Controllers;
using TestStack.FluentMVCTesting;
using CarAdverts.Models;

namespace CarAdvertsSystem.UnitTests.WebTests.ControllersTests.FileControllerTests
{
    [TestFixture]
    public class FileController_Index_Should
    {
        [Test]
        public void ReturnCorrectFileContents()
        {
            // Arrange
            var expectedFile = new File()
            {
                Id = 1,
                Content = new byte[5],
                ContentType = "ContentType"
            };

           var fileService = new Mock<IFileService>();
            fileService.Setup(x => x.GetById(It.IsAny<int>())).Returns(expectedFile);

            var fileController = new FileController(fileService.Object);

            // Act and assert
            fileController.WithCallTo(x => x.Index(It.IsAny<int>())).ShouldRenderFileContents(expectedFile.Content, expectedFile.ContentType);
        }

        [Test]
        public void ReturnNullFileContents()
        {
            File expectedFile = null;

            var fileService = new Mock<IFileService>();
            fileService.Setup(x => x.GetById(It.IsAny<int?>())).Returns(expectedFile);

            var fileController = new FileController(fileService.Object);
            var result = fileController.Index(1);

            // Act and assert
            fileController.WithCallTo(x => x.Index(It.IsAny<int>())).ShouldReturnContent(null);
        }
    }
}
