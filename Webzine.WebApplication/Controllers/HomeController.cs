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
        private IStyleRepository _styleRepository;

        public HomeController(ITitreRepository titreRepository, IStyleRepository styleRepository ,ILogger<HomeController> logger)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into TitreController");
        }

        // GET: HomeController
        // [Route("page")]
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, this is the index!");
            this.model.Titres = _titreRepository.FindAll().ToList();
             _logger.LogInformation("Log en place - Reste plus qu'à les rendre croustillant");
            return this.View(model);
        }
    }
}
