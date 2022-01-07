﻿namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Areas.administration.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des Styles dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    public class StyleController : Controller
    {
        private IStyleRepository _styleRepository;
        private StyleViewModel model = new StyleViewModel();

        public StyleController(IStyleRepository styleRepository)
        {
            this._styleRepository = styleRepository;
        }

        /// <summary>
        /// Page par défaut de la partie administration de Style
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var style = this._styleRepository.FindAll().ToList();
            this.model.Styles = style;
            return this.View(this.model);
        }

        /// <summary>
        /// Page de création d'un Style  
        /// </summary>
        /// <returns></returns>
        public IActionResult Creation()
        {
            return this.View();
        }

        /// <summary>
        /// Page de modification du style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        public IActionResult Edit(int idStyle)
        {
            var style = this._styleRepository.Find(idStyle);
            this.model.Style = style;
            return this.View(this.model);
        }

        /// <summary>
        /// Page de suppression du Style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        public IActionResult Suppression(int idStyle)
        {
            var style = this._styleRepository.Find(idStyle);
            this.model.Style = style;
            return this.View(this.model);
        }

        public IActionResult ValidSuppression(int idStyle)
        {
            Style leStyle = this._styleRepository.Find(idStyle);
            this._styleRepository.Delete(leStyle);
            return this.RedirectToAction("Index");
        }
    }
}
