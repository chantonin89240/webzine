namespace Webzine.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.Repository;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITitreRepository _titreRepository;
        private TitreViewModel model;
        private IStyleRepository _styleRepository;
        public HomeController(ITitreRepository titreRepository, IStyleRepository styleRepository ,ILogger<HomeController> logger)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            this.model = new TitreViewModel();
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into TitreController");
        }

        // GET: HomeController
        // [Route("page")]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            _logger.LogInformation("Hello, this is the index!");
            _logger.LogInformation("Log en place - Reste plus qu'à les rendre croustillant");

            // pageNumber ?? 0 = opération de fusion null, renvoi 0 si pageNumber est null
            this.model.Page = pageNumber ?? 0;

            // Impossible d'avoir deux valeur pour le meme objet??????
            this.model.Titres = this._titreRepository.FindAll().OrderByDescending(titre => titre.DateCreation).ToList();

            this.model.Titres = this.model.TitrePourPage(pageNumber ?? 0);

            this.model.Titres.ForEach(title => title.TitresStyles.ToList().ForEach(ts => ts.Style = this._styleRepository.Find(ts.IdStyle)));

            this.model.TitresPopulaires = this._titreRepository.FindAll().OrderByDescending(titre => titre.NbLectures).Take(3).ToList();

            return this.View(this.model);
        }
    }
}
