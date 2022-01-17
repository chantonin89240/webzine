namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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

        public StyleController(IStyleRepository styleRepository)
        {
            this._styleRepository = styleRepository;
        }

        /// <summary>
        /// Page par défaut de la partie administration de Style.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var style = 
            this.model.Styles = this._styleRepository.FindAll().ToList();
            return this.View(this.model);
        }

        /// <summary>
        /// Page de création d'un Style.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// method qui créer un style 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("create")]
        public IActionResult Create(StyleViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this._styleRepository.Add(model.Style);

                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError(string.Empty, "Impossible d'enregistrer le style. Essayez encore, et si le problème persiste, contactez l'administrateur.");
            
            }

            return this.View();
        }

        /// <summary>
        /// Page de modification du style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            this.model.Style = this._styleRepository.Find(id);
            return this.View(this.model);
        }

        /// <summary>
        /// method qui réalise la modification du style
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("edit")]
        public async Task<IActionResult> Edit(StyleViewModel model, int id)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    model.Style.IdStyle = id;
                    this._styleRepository.Update(model.Style);
                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.
                this.ModelState.AddModelError(string.Empty, "Impossible de sauvegarder les modifications. Essayez encore, et si le problème persiste, contactez l'administrateur.");
            }

            return this.View(model);
        }

        /// <summary>
        /// Page de suppression du Style passé en paramètre.
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            this.model.Style = this._styleRepository.Find(id);
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        public IActionResult Delete(StyleViewModel model, int id)
        {
            var style = this._styleRepository.Find(id);
            this._styleRepository.Delete(style);
            return this.RedirectToAction("Index");
        }
    }
}
