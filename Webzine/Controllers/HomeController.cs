namespace Webzine.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        private ITitreRepository _titreRepository;
        private TitreViewModel model = new TitreViewModel();

        public HomeController(ITitreRepository titreRepository)
        {
            this._titreRepository = titreRepository;
        }

        // GET: HomeController
        public IActionResult Index()
        {
            model.Titres = _titreRepository.FindAll().ToList();

            //model.Titres.ForEach(titre => titre.TitresStyles.ForEach(ts => model.StylesTitre.Add(this.localStyleRepository.Find(ts.IdStyle))));
            return this.View(model);
        }
    }
}
