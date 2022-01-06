namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.Admin.ViewModels;
    [Area("administration")]

    public class ArtisteController : Controller
    {
        LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();

        public IActionResult Index()
        {

            List<Artiste> artistes = localArtisteRepository.FindAll().ToList();
            var model = new ArtisteViewModel() { Artistes = artistes };
            return View(model);
        }

        public IActionResult Creation()
        {
            return View();
        }

        public IActionResult Edit(int IdArtiste)
        {
            Artiste artiste = localArtisteRepository.Find(IdArtiste);
            var model = new ArtisteViewModel()
            {
                Artiste = artiste

            };
            return this.View(model);
        }

        public IActionResult Suppression(int IdArtiste)
        {
            Artiste artiste = localArtisteRepository.Find(IdArtiste);
            var model = new ArtisteViewModel()
            {
                Artiste = artiste
            };
            return this.View(model);
        }

    }
}