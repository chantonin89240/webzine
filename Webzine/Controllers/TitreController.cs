using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class TitreController : Controller
    {
        public IActionResult Titre(int idTitre)
        {
            TitreViewModel vm = new TitreViewModel();
            Titre titre = vm.GetTitre(idTitre);
            return View(titre);
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
