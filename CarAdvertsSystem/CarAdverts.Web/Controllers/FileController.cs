using System.Web.Mvc;
using CarAdverts.Data.Providers.EfProvider;

namespace CarAdverts.Web.Controllers
{
    public class FileController : Controller
    {
        private IEfCarAdvertsDataProvider provider;

        public FileController(IEfCarAdvertsDataProvider provider)
        {
            this.provider = provider;
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = this.provider.Files.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}