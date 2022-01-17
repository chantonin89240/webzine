﻿namespace Webzine.Controllers
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
            this.nbCardChronic = this.configuration.GetSection("Configuration").GetValue<int>("HomePageDisplay");
        }

        // GET: HomeController
        public async Task<IActionResult> Index(int? pageNumber)
        {
            this._logger.LogInformation("Log en place - Reste plus qu'à les rendre croustillant");

            int page = pageNumber ?? 1;
            this.model.Page = page;

            this.model.PageMax = (int)Math.Floor((double)(this._titreRepository.Count()-1) / nbCardChronic) + 1;

            this.model.Titres = this._titreRepository.FindTitres((page - 1) * nbCardChronic, nbCardChronic).ToList();

            this.model.Titres.ForEach(title => title.TitresStyles.ToList().ForEach(ts => ts.Style = this._styleRepository.Find(ts.IdStyle)));

            this.model.TitresPopulaires = this._titreRepository.FindAll().OrderByDescending(titre => titre.NbLectures).Take(3).ToList();

            return this.View(this.model);
        }
    }
}
