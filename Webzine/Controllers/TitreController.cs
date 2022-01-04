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
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(idTitre);
            model.GetStyles(model.Titre);
            model.PrepareCommentaire();

            return View(model);

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
