namespace Webzine.WebApplication.Areas.Admin.Controllers
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
        [ActionName("index")]
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
        [ActionName("creation")]
        public IActionResult Creation()
        {
            return this.View();
        }

        /// <summary>
        /// Page de modification du style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        [ActionName("edit")]
        public IActionResult Edit(int id)
        {
            var style = this._styleRepository.Find(id);
            this.model.Style = style;
            return this.View(this.model);
        }

        /// <summary>
        /// Page de suppression du Style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        [ActionName("suppression")]
        public IActionResult Suppression(int id)
        {
            var style = this._styleRepository.Find(id);
            this.model.Style = style;
            return this.View(this.model);
        }

        [ActionName("supprimer")]
        public IActionResult ValidSuppression(int id)
        {
            Style style = this._styleRepository.Find(id);
            this._styleRepository.Delete(style);
            return this.RedirectToAction("Index");
        }
    }
}
