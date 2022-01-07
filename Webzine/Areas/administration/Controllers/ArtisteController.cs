namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le contröleur pour les vues en rapport aux <see cref="Artiste"/>s dans la partie Administration.
    /// </summary>
    [Area("administration")]
    public class ArtisteController : Controller
    {
        private LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/<see cref="Artiste"/>".
        /// </summary>
        /// <returns>vue d'ensemble de tous les <see cref="Artiste"/>s.</returns>
        public IActionResult Index()
        {

            List<Artiste> artistes = this.localArtisteRepository.FindAll().ToList();
            var model = new ArtisteViewModel() { Artistes = artistes };
            return this.View(model);
        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/Artiste/Creation".
        /// </summary>
        /// <returns>Vue pour la création d'un <see cref="Artiste"/>.</returns>
        public IActionResult Creation()
        {
            return this.View();
        }

        /// <summary>
        /// Renvoie la vue sur chemin "/administration/Artiste/Edit?IdArtiste=(Id de l'<see cref="Artiste"/>)".
        /// </summary>
        /// <param name="idArtiste">Id de l'<see cref="Artiste"/> géré par la vue.</param>
        /// <returns>Vue web pour l'édition d'un <see cref="Artiste"/> qui sera modifié.</returns>
        public IActionResult Edit(int idArtiste)
        {
            Artiste artiste = this.localArtisteRepository.Find(idArtiste);
            var model = new ArtisteViewModel()
            {
                Artiste = artiste,

            };
            return this.View(model);
        }

        /// <summary>
        /// Génère et renvoie la vue de vérification pour la suppression d'un <see cref="Artiste"/>.
        /// </summary>
        /// <param name="idArtiste">ID de l'<see cref="Artiste"/> à supprimer par la vue.</param>
        /// <returns>Vue web pour la suppression d'un <see cref="Artiste"/>.</returns>
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