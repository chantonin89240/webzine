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
        private LocalStyleRepository localStyleRepository = new LocalStyleRepository();

        // GET: HomeController
        public IActionResult Index()
        {
            //HomeViewModel model = new HomeViewModel()

            TitreViewModel model = new TitreViewModel()
            {
                Titres = this.localTitreRepository.FindAll().ToList(),
            }; 
            //model.Titres.ForEach(titre => titre.TitresStyles.ForEach(ts => model.StylesTitre.Add(this.localStyleRepository.Find(ts.IdStyle))));
            return this.View(model);
        }
    }
}
