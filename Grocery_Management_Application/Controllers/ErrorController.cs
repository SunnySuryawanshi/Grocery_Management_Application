using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Grocery_Management_Application.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string errormessage = exceptionHandlerFeature.Error.Message;

            ViewBag.ErrorMessage = errormessage;
            return View("index");
        }

       
    }
}
