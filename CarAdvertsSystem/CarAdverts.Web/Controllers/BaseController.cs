using System;
using System.Web.Mvc;

namespace CarAdverts.Web.Controllers
{
    public class BaseController : Controller
    {
        // This ActionResult will override the existing JsonResult 
        // and will automatically set the maximum JSON length
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue // Use this value to set your maximum size for all of your Requests
            };
        }
    }
}