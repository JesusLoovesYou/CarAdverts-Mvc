using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Services;
using CarAdverts.Models;
using CarAdverts.Models.Contracts;
using System.Web;

namespace CarAdvertsSystem.UnitTests.ServicesTests.AdvertServiceTests
{
    public class AdvertService_AddUploadedFilesToAdvert_Should
    {
        [Test]
        public void ThrowArgumentNullExeption_IfAdvertParameterIsNull()
        {
            // Arrange
            Advert advert = null;
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedEfProvider = new Mock<IEfCarAdvertsDataProvider>();
            var advertService = new AdvertService(mockedEfProvider.Object);

            // Act and Assert
            Assert.That(() => advertService.AddUploadedFilesToAdvert(advert, files),
                Throws.ArgumentNullException);
        }
        ///////////////////////////////////// ...
    }
}
