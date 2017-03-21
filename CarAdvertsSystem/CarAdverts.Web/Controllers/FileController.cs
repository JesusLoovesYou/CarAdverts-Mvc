using System.Web.Mvc;
using CarAdverts.Services.Contracts;

namespace CarAdverts.Web.Controllers
{
    public class FileController : Controller
    {
        private IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }
        
        [HttpGet]
        public ActionResult Index(int id)
        {
            var fileToRetrieve = this.fileService.GetById(id);

            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}