namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        public IActionResult TitresStyle(int idStyle)
        {
            TitreViewModel vm = new TitreViewModel();
            Titre titre = vm.GetTitre(idTitre);
            return View(titre);
            TitreViewModel model = new TitreViewModel();
            model.GetTitres(idStyle).ToList();
            model.GetLibelle(idStyle);

            return this.View(model);
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
