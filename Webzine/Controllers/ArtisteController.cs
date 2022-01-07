namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.ViewModels;

    /// <summary>
    /// Contrôleur pour la vue d'Artistes.
    /// </summary>
    public class ArtisteController : Controller
    {
        private LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();

        /// <summary>
        /// Produit la vue Artiste.
        /// </summary>
        /// <param name="idArtiste">id de l'Artiste documenté par la vue.</param>
        /// <returns>Vue correspondant à un artiste.</returns>
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
