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
    [Route("[controller]")]
    public class StyleController : Controller
    {
        private IStyleRepository _styleRepository;
        private StyleViewModel model = new StyleViewModel();

        [BindProperty]
        public Style style { get; set; }

        public StyleController(IStyleRepository styleRepository)
        {
            this._styleRepository = styleRepository;
        }

        /// <summary>
        /// Page par défaut de la partie administration de Style
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet("[action]")]
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
        [HttpGet("[action]")]
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
        [Route("[action]")]
        public async Task<IActionResult> Create(StyleViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this._styleRepository.Add(model.Style);
                    var tot = model.Style;
                    return RedirectToAction(nameof(Index));
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
        [HttpGet("[action]")]
        public IActionResult Edit(int id)
        {
            var style = this._styleRepository.Find(id);
            this.model.Style = style;
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
        [Route("[action]")]
        public async Task<IActionResult> Edit(StyleViewModel model, int id)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    model.Style.IdStyle = id;
                    this._styleRepository.Update(model.Style);
                    var tot = model.Style;
                    return RedirectToAction(nameof(Index));
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
        /// Page de suppression du Style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult Delete(int id)
        {
            var style = this._styleRepository.Find(id);
            this.model.Style = style;
            return this.View(this.model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("delete")]
        [Route("[action]")]
        public IActionResult Delete(StyleViewModel model, int id)
        {
            Style style = this._styleRepository.Find(id);
            this._styleRepository.Delete(style);
            return this.RedirectToAction("Index");
        }
    }
}
