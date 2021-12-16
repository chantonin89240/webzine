using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class ArtisteController : Controller
    {
        public IActionResult Artiste()
        {
            return View();

        }
    }
}
