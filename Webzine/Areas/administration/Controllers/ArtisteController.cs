namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    [Area("administration")]
    public class ArtisteController : Controller
    {
        private LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();

        public IActionResult Index()
        {

            List<Artiste> artistes = this.localArtisteRepository.FindAll().ToList();
            var model = new ArtisteViewModel() { Artistes = artistes };
            return this.View(model);
        }

        public IActionResult Creation()
        {
            return this.View();
        }

        public IActionResult Edit(int idArtiste)
        {
            Artiste artiste = this.localArtisteRepository.Find(idArtiste);
            var model = new ArtisteViewModel()
            {
                Artiste = artiste,
            };
            return this.View(model);
        }

        public IActionResult Suppression(int idArtiste)
        {
            Artiste artiste = this.localArtisteRepository.Find(idArtiste);
            var model = new ArtisteViewModel()
            {
                Artiste = artiste,
            };
            return this.View(model);
        }
    }
}