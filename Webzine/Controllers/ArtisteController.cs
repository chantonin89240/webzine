namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.ViewModels;

    public class ArtisteController : Controller
    {
        public IActionResult Artiste(int idArtiste)
        {
            ArtisteViewModel artiste = new ArtisteViewModel();
            artiste.GetArtiste(idArtiste);

            return View(artiste);
        }
    }
}
