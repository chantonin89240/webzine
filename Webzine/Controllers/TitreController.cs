using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class TitreController : Controller
    {
        public IActionResult Titre(int idTitre)
        {
            return View();
        }
        public IActionResult AdministrationTitre()
        {
            return View();
        }

        public IActionResult AjoutTitreAdmin()
        {
            return View();
        }

        public IActionResult EditerTitreAdmin()
        {
            return View();
        }

        public IActionResult SupprimerTitreAdmin()
        {
            return View();
        }

    }
}
