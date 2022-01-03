namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    [Area("administration")]

    public class ArtisteController : Controller
    {
        public IActionResult Index()
        {
            ArtisteViewModel model = new ArtisteViewModel();
            model.GetArtistes();
            return View(model.Artistes);
        }

        public IActionResult Creation()
        {
            return View();
        }

        public IActionResult Edit(int IdArtiste)
        {
            ArtisteViewModel model = new ArtisteViewModel();
            model.GetArtiste(IdArtiste);
            return View(model);
        }

        public IActionResult Suppression(int IdArtiste)
        {
            ArtisteViewModel model = new ArtisteViewModel();
            model.GetArtiste(IdArtiste);
            return View(model);
        }

    }
}