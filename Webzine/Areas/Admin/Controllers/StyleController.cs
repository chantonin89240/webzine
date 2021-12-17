using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StyleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
