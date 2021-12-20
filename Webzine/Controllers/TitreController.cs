namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.ViewModels;

    public class TitreController : Controller
    {
        public IActionResult Titre(int idTitre)
        {
            TitreViewModel artiste = new TitreViewModel();
            artiste.GetTitre(idTitre);
            artiste.GetStyles(artiste.Titre);

            return View(artiste);

        }
        public IActionResult TitresStyle(int idStyle)
        {

            TitreViewModel model = new TitreViewModel();
            model.GetTitres(idStyle).ToList();
            model.GetLibelle(idStyle);

            return this.View(model);
        }

    }
}
