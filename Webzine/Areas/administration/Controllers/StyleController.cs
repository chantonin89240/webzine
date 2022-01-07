namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository;
    using Webzine.WebApplication.Areas.administration.ViewModels;

    /// <summary>
    /// Représente le controlleur pour la partie des Styles dans la zone d'administration.
    /// </summary>
    [Area("administration")]
    public class StyleController : Controller
    {
        LocalStyleRepository LocalStyleRepository = new LocalStyleRepository();
        
        /// <summary>
        /// Page par défaut de la partie administration de Style
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var style = this.LocalStyleRepository.FindAll().ToList();

            var model = new StyleViewModel()
            {
                Styles = style
            };
            return this.View(model);
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
            var style = this.LocalStyleRepository.Find(idStyle);

            var model = new StyleViewModel()
            {
                Style = style
            };
            return this.View(model);
        }

        /// <summary>
        /// Page de suppression du Style passé en paramètre
        /// </summary>
        /// <param name="idStyle"></param>
        /// <returns></returns>
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
