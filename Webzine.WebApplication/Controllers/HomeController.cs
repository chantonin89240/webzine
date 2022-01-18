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
        private TitreViewModel model;
        private IStyleRepository _styleRepository;
        private readonly IConfiguration configuration;
        private int nbCardChronic;

        public HomeController(ITitreRepository titreRepository, IStyleRepository styleRepository ,ILogger<HomeController> logger, IConfiguration configuration)
        {
            this._titreRepository = titreRepository;
            this._styleRepository = styleRepository;
            this.model = new TitreViewModel();
            this._logger = logger;
            this._logger.LogDebug(1, "NLog injected into TitreController");
            this.configuration = configuration;
            this.nbCardChronic = this.configuration.GetSection("Configuration").GetSection("HomePageDisplay").GetValue<int>("NbCardChronic");
        }

        // GET: HomeController
        public async Task<IActionResult> Index(int? pageNumber)
        {
            this._logger.LogInformation("Log en place - Reste plus qu'à les rendre croustillant");

            int page = pageNumber ?? 1;
            this.model.Page = page;

            if (this.nbCardChronic > 0)
            {
                this.model.PageMax = (int)Math.Floor((double)(this._titreRepository.Count() - 1) / nbCardChronic) + 1;
                this.model.Titres = this._titreRepository.FindTitres((page - 1) * nbCardChronic, nbCardChronic).ToList();
            }
            else
            {
                this.model.PageMax = 1;
                this.model.Titres = new List<Entity.Titre>();
            }

            this.model.Titres.ForEach(title => title.TitresStyles.ToList().ForEach(ts => ts.Style = this._styleRepository.Find(ts.IdStyle))) ;
            int nbPopular = this.configuration.GetSection("Configuration").GetSection("HomePageDisplay").GetValue<int>("NbPopularCard");

            if (nbPopular > 0)
            {
                this.model.TitresPopulaires = this._titreRepository.FindAll().OrderByDescending(titre => titre.NbLectures).Take(nbPopular).ToList();
            }
            else
            {
                this.model.TitresPopulaires = new List<Entity.Titre>();
            }

            return this.View(this.model);
        }
    }
}
