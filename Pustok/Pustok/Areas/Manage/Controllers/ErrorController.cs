using Microsoft.AspNetCore.Mvc;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
