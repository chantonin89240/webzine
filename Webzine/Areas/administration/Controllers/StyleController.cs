namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Microsoft.EntityFrameworkCore;
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

        [BindProperty]
        public Style  style { get; set; }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("creer")]
        public async Task<IActionResult> Creer(StyleViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    //var styleIsOk = this._styleRepository.rechercheStyle(model.Style);
                    //if (styleIsOk == true)
                    //{

                        this._styleRepository.Add(model.Style);
                        var tot = model.Style;
                        return RedirectToAction(nameof(Index));
                    //}
                    
                }
            }
            catch (DbUpdateException /* ex */)
            {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }
            return this.View(model.Style);
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
