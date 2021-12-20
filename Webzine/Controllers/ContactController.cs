using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
