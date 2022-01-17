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
        private IModeratorServices _moderator;
        private TitreViewModel model;
        private static List<string>? _editOldIdStyle;
        private static List<Artiste>? _editArtisteSelect;
        private static Artiste? _editTitreArtiste;
        private static DateTime _dateCréation;
        private static List<Style>? _stylesListForCheckbox;

        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository, IModeratorServices moderator)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            this._artisteRepository = artisteRepository;
            this._moderator = moderator;
            this.model = new TitreViewModel();
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
            _editArtisteSelect = this._artisteRepository.FindAll().ToList();
            _stylesListForCheckbox = this._styleRepository.FindAll().ToList();
            this.model.Artistes = _editArtisteSelect;
            this.model.Styles = _stylesListForCheckbox;
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
            var listIdStyle = this.Request.Form["ListeStyles"].ToList();
            model.Styles = _stylesListForCheckbox;
            model.Artistes = _editArtisteSelect;
            listIdStyle.ForEach(id => 
                model.Titre.TitresStyles.Append
                ( 
                    new TitreStyle() { IdStyle=Convert.ToInt32(id), IdTitre = model.Titre.IdTitre}
                )
            );
            try
            {
                if (ModelState.IsValid) 
                {
                    if(!this._moderator.ModerationCreateChronique(model.Titre, listIdStyle))
                    {          
                        ModelState.AddModelError(string.Empty, "Votre chronique ne respecte pas la charte du site");
                        return this.View(model);
                    }
                    return this.RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException  ex )
            {
                // Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError(string.Empty, "Impossible d'enregistrer le titre. Essayez encore, et si le problème persiste, contactez l'administrateur.");
            }
            return this.View(model);
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
            _editOldIdStyle = this.model.Titre.TitresStyles.Select(ts => ts.IdStyle.ToString()).Distinct().ToList();
            _dateCréation = this.model.Titre.DateCreation;
            _editArtisteSelect = this._artisteRepository.FindAll().ToList();
            _stylesListForCheckbox = this._styleRepository.FindAll().ToList();
            this.model.Artistes = _editArtisteSelect;
            this.model.Styles = _stylesListForCheckbox;
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
            var newIdStyle = this.Request.Form["ListeStyles"].ToList();
            model.Titre.IdTitre = id;
            model.Titre.DateCreation = _dateCréation;
            model.Artistes = _editArtisteSelect;
            model.Styles =_stylesListForCheckbox;
            newIdStyle.ForEach(id => 
                model.Titre.TitresStyles.Append
                ( 
                    new TitreStyle() { IdStyle=Convert.ToInt32(id), IdTitre = model.Titre.IdTitre}
                )
            );
            
            try
            {
                if (this.ModelState.IsValid)
                {
                    if(!this._moderator.ModerationEditChronique(model.Titre, newIdStyle, _editOldIdStyle))
                    {
                        ModelState.AddModelError(string.Empty, "Votre chronique ne respecte pas la charte du site");
                        return this.View(model);
                    }
                    
                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log).
                this.ModelState.AddModelError(string.Empty, "Impossible de sauvegarder les modifications. Essayez encore, et si le problème persiste, contactez l'administrateur.");
            }

            return this.View(model);
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
                var titre = this._titreRepository.Find(id);
                this._titreRepository.Delete(titre);
                return this.RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex )
            {
                // Log the error (uncomment ex variable name and write a log).
                this.ModelState.AddModelError(string.Empty, "Inpossible de supprimer le titre. Essayez encore, et si le problème persiste, contactez l'administrateur.");
            }

            return this.View();
        }
    }
}
