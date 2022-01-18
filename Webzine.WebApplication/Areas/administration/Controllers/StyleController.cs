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
        private IStyleRepository styleRepository;
        private StyleViewModel model;

        // constructeur de StyleControlleur
        public StyleController(IStyleRepository styleRepository)
        {
            this.styleRepository = styleRepository;
            this.model = new StyleViewModel();
        }

        /// <summary>
        /// Page par défaut de la partie administration de Style.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            this.model.Styles = this.styleRepository.FindAll().ToList();
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
        /// methode qui créer le style passé en paramètre
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
                    this.styleRepository.Add(model.Style);

                    return this.RedirectToAction(nameof(this.Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.
                this.ModelState.AddModelError(string.Empty, "Impossible d'enregistrer le style. Essayez encore, et si le problème persiste, contactez l'administrateur.");
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
            this.model.Style = this.styleRepository.Find(id);
            return this.View(this.model);
        }

        /// <summary>
        /// methode qui réalise la modification du style passé en paramètre
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
                    this.styleRepository.Update(model.Style);
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
            this.model.Style = this.styleRepository.Find(id);
            return this.View(this.model);
        }

        /// <summary>
        /// methode qui supprime le style passé en paramètre 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        public IActionResult Delete(StyleViewModel model, int id)
        {
            var style = this.styleRepository.Find(id);
            this.styleRepository.Delete(style);
            return this.RedirectToAction("Index");
        }
    }
}
