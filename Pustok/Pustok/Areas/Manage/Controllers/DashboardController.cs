using Microsoft.AspNetCore.Mvc;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
