using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using CarAdverts.Data.Repositories.EfRepository.Contracts;
using CarAdverts.Models;

namespace CarAdvertsSystem.UnitTests.ServicesTests.FileServceTests
{
    [TestFixture]
    public class FileService_GetByIdShould
    {
        [Test]
        public void ReturnNull_IfParameterIdIsNull()
        {
            // Arrange
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            // Act
            var fileService = new FileService(mockedEfProvider.Object);
            var result = fileService.GetById(null);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void InvoceEfProviderMethodGetById_Once_IfParameterIdIsNotNull()
        {
            // Arrange
            var mockedFileRepository = new Mock<IEfGenericRepository<File>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Files).Returns(mockedFileRepository.Object);

            // Act
            var fileService = new FileService(mockedEfProvider.Object);
            var result = fileService.GetById(1);

            // Assert
            mockedFileRepository.Verify(p => p.GetById(It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void InvoceEfProviderMethodGetById_Never_IfParameterIdIsNull()
        {
            // Arrange
            var mockedFileRepository = new Mock<IEfGenericRepository<File>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            mockedEfProvider.Setup(p => p.Files).Returns(mockedFileRepository.Object);

            // Act
            var fileService = new FileService(mockedEfProvider.Object);
            var result = fileService.GetById(null);

            // Assert
            mockedFileRepository.Verify(p => p.GetById(It.IsAny<int?>()), Times.Never);
        }

        [Test]
        public void ReturnCorrectFile_IfParameterIdIsValid_AndThereIsFileWithIdEqualOfParamId()
        {
            // Arrange
            var expectedFile = new File() { Id = 1 };

            var mockedFileRepository = new Mock<IEfGenericRepository<File>>();
            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();

            mockedEfProvider.Setup(p => p.Files).Returns(mockedFileRepository.Object);
            mockedFileRepository.Setup(f => f.GetById(It.IsAny<int>())).Returns(expectedFile);

            // Act
            var fileService = new FileService(mockedEfProvider.Object);
            var result = fileService.GetById(1);

            // Assert
            Assert.AreEqual(result, expectedFile);
        }
    }
}
