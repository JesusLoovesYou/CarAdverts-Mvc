using System.Web.Mvc;
using CarAdverts.Services.Contracts;
using Bytes2you.Validation;

namespace CarAdverts.Web.Controllers
{
    public class FileController : Controller
    {
        private IFileService fileService;

        public FileController(IFileService fileService)
        {
            Guard.WhenArgument(fileService, nameof(fileService)).IsNull().Throw();

            this.fileService = fileService;
        }
        
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var fileToRetrieve = this.fileService.GetById(id);

            if (fileToRetrieve == null)
            {
                return Content(null);
            }

            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}