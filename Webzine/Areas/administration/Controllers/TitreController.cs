namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des <see cref="Titre"/>s dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    public class TitreController : Controller
    {
        private LocalTitreRepository localTitreRepository = new LocalTitreRepository();
        private LocalStyleRepository localStyleRepository = new LocalStyleRepository();
        private LocalArtisteRepository localArtisteRepository = new LocalArtisteRepository();

        /// <summary>
        /// Page par défaut du controlleur: Une vue d'ensemble de tous les <see cref="Titre"/>s, en mode d'administration.
        /// </summary>
        /// <returns>
        /// La vue correspondante à l'administration des <see cref="Titre"/>s.
        /// </returns>
        public IActionResult Index()
        {
            TitreViewModel model = new TitreViewModel()
            {
                Titres = this.localTitreRepository.FindAll().ToList(),
            };
            return this.View(model);
        }

        /// <summary>
        /// Page de création d'un nouveau <see cref="Titre"/>.
        /// </summary>
        /// <returns>
        /// Une page permettant la création d'un nouveau <see cref="Titre"/>.
        /// </returns>
        public IActionResult Creation()
        {
            TitreViewModel model = new TitreViewModel()
            {
                Artistes = this.localArtisteRepository.FindAll().ToList(),
                Styles = this.localStyleRepository.FindAll().ToList(),
            };
            return this.View(model);
        }

        /// <summary>
        /// Page permettant la modification des données enregistrées sur un <see cref="Titre"/>.
        /// Préchargé avec les données déja enregistrées.
        /// </summary>
        /// <param name="id">ID Du <see cref="Titre"/> à éditer.</param>
        /// <returns>
        /// La page de modification d'un <see cref="Titre"/>.
        /// </returns>
        public IActionResult Edit(int id)
        {
            TitreViewModel model = new TitreViewModel()
            {
                Titre = this.localTitreRepository.Find(id),
                Artistes = this.localArtisteRepository.FindAll().ToList(),
                Styles = this.localStyleRepository.FindAll().ToList(),
            };
            return this.View(model);
        }

        /// <summary>
        /// Page de vérification de la suppression d'un <see cref="Titre"/>.
        /// Charge certaines données du <see cref="Titre"/>.
        /// </summary>
        /// <param name="id">ID du <see cref="Titre"/> à supprimer.</param>
        /// <returns>
        /// Page de vérification de suppression.
        /// </returns>
        public IActionResult Suppression(int id)
        {
            TitreViewModel model = new TitreViewModel()
            {
                Titre = this.localTitreRepository.Find(id),
            };

            this.localTitreRepository.Delete(model.Titre);
            return this.View(model);
        }

    }
}
