namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.Services;
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
        private TitreViewModel model;
        private Moderator moderator;
        private static List<string> _editStylesTitre = new List<string>();
        private static DateTime _dateCréation;

        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            this._artisteRepository = artisteRepository;
            this.model = new TitreViewModel();
            this.moderator = new Moderator(titreRepository);
        }

        /// <summary>
        /// GET : /administration/titres/
        /// Page par défaut du controlleur: Une vue d'ensemble de tous les <see cref="Titre"/>s, en mode d'administration.
        /// </summary>
        /// <returns>
        /// La vue correspondante à l'administration des <see cref="Titre"/>s.
        /// </returns>
        public IActionResult Index()
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Debug("Entrée dans index.");
            this.model.Titres = this._titreRepository.FindAll().ToList();
            // this.model.Titres.ForEach(t => this.model.DateToString(t));
            return this.View(this.model);
        }

        /// <summary>
        /// GET : /administration/titre/create
        /// Page de création d'un nouveau <see cref="Titre"/>.
        /// </summary>
        /// <returns>
        /// Une page permettant la création d'un nouveau <see cref="Titre"/>.
        /// </returns>
        public IActionResult Create()
        {
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// POST : /administration/titres/create
        /// action du formulaire de création d'un titre.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>La vue index mis à jour</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("create")]
        public IActionResult Create(TitreViewModel model)
        {

            try
            {
                // if (ModelState.IsValid)
                // {

                    var listIdStyle = this.Request.Form["ListeStyles"].ToList();

                    this.moderator.ModerationText(model.Titre, listIdStyle);
                    // this._titreRepository.Add(model.Titre);
                    // this._titreRepository.AddStyles(model.Titre, listIdStyle);  
                    return this.RedirectToAction(nameof(Index));
                // }
            }
            catch (DbUpdateException  ex )
            {
                // Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError(string.Empty, "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
            }

            return this.View(model.Titre);
        }

        /// <summary>
        /// GET : /administration/titres/edit?id=
        /// Page de modification des données enregistrées sur un <see cref="Titre"/>.
        /// Préchargé avec les données déja enregistrées.
        /// </summary>
        /// <param name="id">ID Du <see cref="Titre"/> à éditer.</param>
        /// <returns>La page de modification d'un <see cref="Titre"/></returns>
        public IActionResult Edit(int id)
        {
            this.model.Titre = this._titreRepository.Find(id);
            _editStylesTitre = this.model.Titre.TitresStyles.Select(ts => ts.IdStyle.ToString()).Distinct().ToList();
            _dateCréation = this.model.Titre.DateCreation;
            this.model.Artistes = this._artisteRepository.FindAll().ToList();
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// POST : /administration/titres/edit?id=
        /// action du formulaire de modification d'un titre.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>La vue index mis à jour</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("edit")]
        public IActionResult Edit(TitreViewModel model, int id)
        {
            try
            {
                // if (this.ModelState.IsValid)
                // {
                    var listIdStyle = this.Request.Form["ListeStyles"].ToList();
                    model.Titre.IdTitre = id;
                    model.Titre.DateCreation = _dateCréation;
                    // titre.DateCreation = DateTime.Now;
                    if(listIdStyle != _editStylesTitre)
                    {
                        var listRemove = _editStylesTitre.Except(listIdStyle).ToList();
                        var listAdd = listIdStyle.Except(_editStylesTitre).ToList();
                        this._titreRepository.UpdateStyles(id, listRemove, listAdd);
                    }

                    this._titreRepository.Update(model.Titre);
                    return this.RedirectToAction(nameof(this.Index));
                //}
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log).
                this.ModelState.AddModelError(string.Empty, "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
            }

            return this.View(model.Titre);
        }

        /// <summary>
        /// POST : /administration/artiste/delete/1
        /// Page de vérification de la suppression d'un <see cref="Titre"/>.
        /// Charge certaines données du <see cref="Titre"/>.
        /// </summary>
        /// <param name="id">ID du <see cref="Titre"/> à supprimer.</param>
        /// <returns>Page de vérification de suppression.</returns>
        public IActionResult Delete(int id)
        {
            this.model.Titre = this._titreRepository.Find(id);
            return this.View(this.model);
        }

        /// <summary>
        /// POST : /administration/artiste/delete/1
        /// action du formulaire de suppression d'un titre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La vue Index mise à jour</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        public IActionResult Delete(TitreViewModel model, int id)
        {
            try
            {
                // if (this.ModelState.IsValid)
                // {
                    var titre = this._titreRepository.Find(id);
                    this._titreRepository.Delete(titre);
                    return this.RedirectToAction(nameof(Index));
                // }
            }
            catch (DbUpdateException ex )
            {
                // Log the error (uncomment ex variable name and write a log).
                this.ModelState.AddModelError(string.Empty, "Unable to save changes. " + " Try again, and if the problem persists " + " see your system administrator.");
            }

            return this.View();
        }
    }
}
