namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.ViewModels;

    public class ArtisteController : Controller
    {
        private LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();
        public IActionResult Artiste(int idArtiste)
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
