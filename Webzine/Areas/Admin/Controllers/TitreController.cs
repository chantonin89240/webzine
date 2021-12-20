namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    [Area("Admin")]

    public class TitreController : Controller
    {
        public IActionResult Index()
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitres();
            return this.View(model.Titres);
        }

        public IActionResult Creation()
        {
            TitreViewModel model = new TitreViewModel();
            model.GetStyles();
            model.GetArtistes();

            return this.View(model);
        }

        public IActionResult Edit(int IdTitre)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(IdTitre);
            model.GetStyle(model.Titre);
            model.GetStyles();
            model.GetArtistes();

            return this.View(model);
        }

        public IActionResult Suppression(int IdTitre)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(IdTitre);
            return this.View(model.Titre);
        }

    }
}
