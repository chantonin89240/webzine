namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    [Area("administration")]

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

        public IActionResult Edit(int id)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(id);
            model.GetStyle(model.Titre);
            model.GetStyles();
            model.GetArtistes();

            return this.View(model);
        }

        public IActionResult Suppression(int id)
        {
            TitreViewModel model = new TitreViewModel();
            model.GetTitre(id);
            return this.View(model.Titre);
        }

    }
}
