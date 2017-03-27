using System.Collections.Generic;
using System.Linq;
using CarAdverts.Web.Areas.User.Models;
using CarAdverts.Web.Models;
using CarAdverts.Web.Models.Advert;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.WebTests.ViewModelsTests.AdvertViewModels.AdvertInputViewModelsTests
{
    [TestFixture]
    public class AdvertInputViewModel_FilesToBeUploaded
    {
       [Test]
        public void GetAndSetDataCorrectly()
        {
            // Arrange and Act
            var testFiles = new List<FileViewModel>()
            {
                new FileViewModel() {Id = 1},
                new FileViewModel() {Id = 2},
            };

            var viewModel = new AdvertInputViewModel { FilesToBeUploaded = testFiles };

            // Assert
            Assert.AreEqual(testFiles[0].Id, viewModel.FilesToBeUploaded.ToList()[0].Id);
            Assert.AreEqual(testFiles[1].Id, viewModel.FilesToBeUploaded.ToList()[1].Id);
        }

    }
}
