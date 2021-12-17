using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    public class StyleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
