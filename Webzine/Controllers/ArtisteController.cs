namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;
    using Webzine.ViewModels;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Contrôleur pour la vue d'Artistes.
    /// </summary>
    public class ArtisteController : Controller
    {
        private IArtisteRepository _artisteRepository;
        private ArtisteViewModel model = new ArtisteViewModel();

        public ArtisteController(IArtisteRepository artisteRepository)
        {
            this._artisteRepository = artisteRepository;
        }

        /// <summary>
        /// Produit la vue Artiste.
        /// </summary>
        /// <param name="idArtiste">id de l'Artiste documenté par la vue.</param>
        /// <returns>Vue correspondant à un artiste.</returns>
        public IActionResult Artiste(int idArtiste)
        {
            model.Artiste = _artisteRepository.Find(idArtiste);

            return this.View(model);
        }
    }
}
