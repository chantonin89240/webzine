﻿namespace Webzine.WebApplication.Areas.Admin.Controllers
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
        /// GET : /administration/titres/
        /// Page par défaut du controlleur: Une vue d'ensemble de tous les <see cref="Titre"/>s, en mode d'administration.
        /// </summary>
        /// <returns>
        /// La vue correspondante à l'administration des <see cref="Titre"/>s.
        /// </returns>
        [HttpGet]
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
        /// GET : /administration/titre/create
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

        /// <summary>
        /// POST : /administration/titres/create
        /// action du formulaire de création d'un titre.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>La vue index mis à jour</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("createAsk")]
        [Route("[action]")]
        public IActionResult CreateAsk(TitreViewModel model)
        {
            try
            {
                // if (ModelState.IsValid)
                // {
                    var listIdStyle = this.Request.Form["ListeStyles"].ToList();
                    this._titreRepository.Add(model.Titre);
                    this._titreRepository.AddStyles(model.Titre, listIdStyle);  
                    return this.RedirectToAction(nameof(Index));
                // }
            }
            catch (DbUpdateException  ex )
            {
                //Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }
            return this.View();
        }

        /// <summary>
        /// GET : /administration/titres/edit?id=
        /// Page de modification des données enregistrées sur un <see cref="Titre"/>.
        /// Préchargé avec les données déja enregistrées.
        /// </summary>
        /// <param name="id">ID Du <see cref="Titre"/> à éditer.</param>
        /// <returns>La page de modification d'un <see cref="Titre"/></returns>
        [Route("[action]")]
        public IActionResult Edit(int id)
        {
            this.model.Titre = this._titreRepository.Find(id);
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
        [ActionName("editAsk")]
        [Route("[action]")]
        public IActionResult EditAsk(TitreViewModel model, int id)
        {
            try
            {
            //     if (ModelState.IsValid)
            //     {
                    var listIdStyle = this.Request.Form["ListeStyles"].ToList();
                    // var idArtiste = titre.IdArtiste;
                    // titre.DateCreation = DateTime.Now;
                    // var toto = this.model.Titre.TitresStyles.Select(ts => ts.IdStyle);
                    // if(listIdStyle != toto)
                    // {
                    //     Console.WriteLine("Yes");
                    //     // this._titreRepository.UpdateStyles(model.Titre, listIdStyle);
                    // }
                    model.Titre.IdTitre = id;
                    this._titreRepository.Update(model.Titre);
                    return this.RedirectToAction(nameof(Index));
            //     }
            }
            catch (DbUpdateException  ex )
            {
                //Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
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
        public IActionResult DeleteAsk(int id)
        {
            try
            {
                var titre = this._titreRepository.Find(id);
                this._titreRepository.Delete(titre);
                return this.RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex )
            {
                //Log the error (uncomment ex variable name and write a log).
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }
            return this.View();
        }

        /// <summary>
        /// POST : /titre/liker
        /// action de like un titre.
        /// </summary>
        /// <returns></returns>
        // [HttpPost]
        // public IActionResult Liker(TitreViewModel model)
        // {
        //     try
        //     {
        //         this._titreRepository.IncrementNbLikes(model.Titre);
        //     }
        //     catch (DbUpdateException ex )
        //     {
        //         //Log the error (uncomment ex variable name and write a log).
        //         ModelState.AddModelError("", "Unable to save changes. " +
        //         "Try again, and if the problem persists " +
        //         "see your system administrator.");
        //     }
        // }
    }
}