namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.administration.ViewModels;

    /// <summary>
    /// Contrôleur des pages administrative en rapport avec les <see cref="Style"/>s.
    /// </summary>
    [Area("administration")]
    public class StyleController : Controller
    {
        private LocalStyleRepository LocalStyleRepository = new LocalStyleRepository();

        /// <summary>
        /// Page administrative listant tous les <see cref="Style"/>s.
        /// </summary>
        /// <returns>Page web correspondante.</returns>
        public IActionResult Index()
        {
            var style = this.LocalStyleRepository.FindAll().ToList();

            var model = new StyleViewModel()
            {
                Styles = style,
            };
            return this.View(model);
        }

        /// <summary>
        /// Page permettant la création d'un nouveau <see cref="Style"/>.
        /// </summary>
        /// <returns>page web correspondante.</returns>
        public IActionResult Creation()
        {
            return this.View();
        }

        /// <summary>
        /// Page permettant la modification d'un <see cref="Style"/>.
        /// </summary>
        /// <param name="idStyle">ID du <see cref="Style"/> qui sera modifié.</param>
        /// <returns>page web correspondante.</returns>
        public IActionResult Edit(int idStyle)
        {
            var style = this.LocalStyleRepository.Find(idStyle);

            var model = new StyleViewModel()
            {
                Style = style,
            };
            return this.View(model);
        }

        /// <summary>
        /// Page vérifiant la suppression d'un <see cref="Style"/>.
        /// </summary>
        /// <param name="idStyle">ID du <see cref="Style"/> à supprimer.</param>
        /// <returns>Page correspondante.</returns>
        public IActionResult Suppression(int idStyle)
        {
            var style = this.LocalStyleRepository.Find(idStyle);

            var model = new StyleViewModel()
            {               
                Style = style
            };
            return this.View(model);
        }
    }
}
