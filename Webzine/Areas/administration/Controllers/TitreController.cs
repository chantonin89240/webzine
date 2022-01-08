namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des <see cref="Titre"/>s dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    public class TitreController : Controller
    {
        private ITitreRepository _titreRepository;
        private IStyleRepository _styleRepository;
        private IArtisteRepository _artisteRepository;
        private TitreViewModel model = new TitreViewModel();

        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            this._artisteRepository = artisteRepository;
        }
        /// <summary>
        /// Page par défaut du controlleur: Une vue d'ensemble de tous les <see cref="Titre"/>s, en mode d'administration.
        /// </summary>
        /// <returns>
        /// La vue correspondante à l'administration des <see cref="Titre"/>s.
        /// </returns>
        public IActionResult Index()
        {   var url = this.Url.ActionContext.HttpContext.Request.RouteValues["area"];
            this.model.Titres = this._titreRepository.FindAll().ToList();
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
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(model);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        [ActionName("new")]
        public IActionResult Creer()
        {
            //this._titreRepository.Add(titre);
            return this.RedirectToAction("Index");
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
            this.model.Titre = this._titreRepository.Find(id);
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();

            return this.View(model);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        [ActionName("update")]
        public IActionResult Maj(int id)
        {
            var titre = this._titreRepository.Find(id);
            this._titreRepository.Update(titre);
            return this.RedirectToAction("Index");
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
            this.model.Titre = this._titreRepository.Find(id);
            return this.View(model);
        }

        [ActionName("delete")]
        public IActionResult Supprimer(int id)
        {
            var titre = this._titreRepository.Find(id);
            this._titreRepository.Delete(titre);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
