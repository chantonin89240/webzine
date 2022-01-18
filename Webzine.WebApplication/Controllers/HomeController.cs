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
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> logger;
        private ITitreRepository titreRepository;
        private TitreViewModel model;
        private IStyleRepository styleRepository;
        private int nbCardChronic;

        /// <summary>
        /// Initialize une instance de classe <see cref="HomeController"/>.
        /// </summary>
        /// <param name="titreRepository">Repos de Titres.</param>
        /// <param name="styleRepository">Repos de Styles.</param>
        /// <param name="logger">Log d'erreurs.</param>
        /// <param name="configuration">configuration.</param>
        public HomeController(ITitreRepository titreRepository, IStyleRepository styleRepository ,ILogger<HomeController> logger, IConfiguration configuration)
        {
            this.titreRepository = titreRepository;
            this.styleRepository = styleRepository;
            this.model = new TitreViewModel();
            this.logger = logger;
            this.logger.LogDebug(1, "NLog injected into TitreController");
            this.configuration = configuration;
            this.nbCardChronic = this.configuration.GetSection("Configuration").GetValue<int>("HomePageDisplay");
        }

        // GET: HomeController
        /// <summary>
        /// Accesseur de la page Index.
        /// </summary>
        /// <param name="pageNumber">Numéro de la page.</param>
        /// <returns>Page index avec les titres correspondant au numéro de page.</returns>
        public IActionResult Index(int? pageNumber)
        {
            this.logger.LogInformation("Affichage Index HomeController");

            int page = pageNumber ?? 1;
            this.model.Page = page;

            if (this.nbCardChronic > 0)
            {
                this.model.PageMax = (int)Math.Floor((double)(this.titreRepository.Count() - 1) / nbCardChronic) + 1;
                this.model.Titres = this.titreRepository.FindTitres((page - 1) * nbCardChronic, nbCardChronic).ToList();
            }
            else
            {
                this.model.PageMax = 1;
                this.model.Titres = new List<Entity.Titre>();
            }

            this.model.Titres.ForEach(title => title.TitresStyles.ToList().ForEach(ts => ts.Style = this.styleRepository.Find(ts.IdStyle)));
            this.model.TitresPopulaires = this.titreRepository.FindAll().OrderByDescending(titre => titre.NbLectures).Take(3).ToList();

            return this.View(this.model);
        }
    }
}
