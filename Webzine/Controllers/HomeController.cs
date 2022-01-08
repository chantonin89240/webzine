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
        private readonly ILogger<HomeController> _logger;
        private ITitreRepository _titreRepository;
        private TitreViewModel model = new TitreViewModel();

        public HomeController(ITitreRepository titreRepository, ILogger<HomeController> logger)
        {
            this._titreRepository = titreRepository;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into TitreController");
        }

        // GET: HomeController
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            model.Titres = _titreRepository.FindAll().ToList();

            //model.Titres.ForEach(titre => titre.TitresStyles.ForEach(ts => model.StylesTitre.Add(this.localStyleRepository.Find(ts.IdStyle))));
             _logger.LogInformation("Log en place - Reste plus qu'à les rendre croustillant");
            return this.View(model);
        }
    }
}
