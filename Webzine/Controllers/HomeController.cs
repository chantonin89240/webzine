namespace Webzine.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        //private HomeViewModel model = new HomeViewModel();
        private LocalTitreRepository localTitreRepository = new LocalTitreRepository();

        // GET: HomeController
        public IActionResult Index()
        {
            TitreViewModel model = new TitreViewModel()
            {
                Titres = this.localTitreRepository.FindAll().ToList(),
            };
            return this.View(model);
        }
    }
}
