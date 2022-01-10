namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Microsoft.EntityFrameworkCore;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Areas.Admin.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des <see cref="Titre"/>s dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    [Route("[area]/[controller]/")]
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
        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {   
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Debug("Entrée dans index.");
            this.model.Titres = this._titreRepository.FindAll().ToList();
            // this.model.Titres.ForEach(t => this.model.DateToString(t));
            return this.View(this.model);
        }

        /// <summary>
        /// Page de création d'un nouveau <see cref="Titre"/>.
        /// </summary>
        /// <returns>
        /// Une page permettant la création d'un nouveau <see cref="Titre"/>.
        /// </returns>
        [Route("[action]")]
        public IActionResult Create()
        {
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        [ActionName("createAsk")]
        [Route("[action]")]
        public IActionResult CreateAsk(Titre titre)
        {
            // try
            // {
            //     if (ModelState.IsValid)
            //     {
                    // var idArtiste = titre.IdArtiste;
                    //titre.Artiste = this._artisteRepository.Find(idArtiste);
                    var listIdStyle = this.Request.Form["Styles"].ToList();
                    this._titreRepository.Add(titre);
                    return this.RedirectToAction(nameof(Index));
            //     }
            // }
            // catch (DbUpdateException /* ex */)
            // {
            //     //Log the error (uncomment ex variable name and write a log).
            //     ModelState.AddModelError("", "Unable to save changes. " +
            //     "Try again, and if the problem persists " +
            //     "see your system administrator.");
            // }
            // return this.View();
        }

        /// <summary>
        /// Page permettant la modification des données enregistrées sur un <see cref="Titre"/>.
        /// Préchargé avec les données déja enregistrées.
        /// </summary>
        /// <param name="id">ID Du <see cref="Titre"/> à éditer.</param>
        /// <returns>
        /// La page de modification d'un <see cref="Titre"/>.
        /// </returns>
        [Route("[action]")]
        public IActionResult Edit(int id)
        {
            this.model.Titre = this._titreRepository.Find(id);
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("editAsk")]
        [Route("[action]")]
        public IActionResult EditAsk(Titre titre, int id)
        {
            // try
            // {
            //     if (ModelState.IsValid)
            //     {
                    var toto = titre;
                    // var idArtiste = titre.IdArtiste;
                    titre.IdTitre = id;
                    // titre.DateCreation = DateTime.Now;
                    this._titreRepository.Update(titre);
                    return this.RedirectToAction(nameof(Index));
            //     }
            // }
            // catch (DbUpdateException /* ex */)
            // {
            //     //Log the error (uncomment ex variable name and write a log).
            //     ModelState.AddModelError("", "Unable to save changes. " +
            //     "Try again, and if the problem persists " +
            //     "see your system administrator.");
            // }
            // return this.View(titre);
        }

        /// <summary>
        /// Page de vérification de la suppression d'un <see cref="Titre"/>.
        /// Charge certaines données du <see cref="Titre"/>.
        /// </summary>
        /// <param name="id">ID du <see cref="Titre"/> à supprimer.</param>
        /// <returns>
        /// Page de vérification de suppression.
        /// </returns>
        [Route("[action]")]
        public IActionResult Delete(int id)
        {
            this.model.Titre = this._titreRepository.Find(id);
            return this.View(this.model);
        }

        [Route("[action]")]
        [ActionName("deleteAsk")]
        public IActionResult DeleteAsk(int id)
        {
            try
            {
                var titre = this._titreRepository.Find(id);
                this._titreRepository.Delete(titre);
                return this.RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }
            return this.View();
        }
    }
}
