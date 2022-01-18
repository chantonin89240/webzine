namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.ViewModels;

    public class RechercheController : Controller
    {
        private IArtisteRepository artisteRepository;
        private ITitreRepository titreRepository;
        private RechercheViewModel model;

        /// <summary>
        /// Initialize une nouvelle instance de classe <see cref="RechercheController"/>.
        /// </summary>
        /// <param name="artisteRepository">Repos d'artistes.</param>
        /// <param name="titreRepository">repos de titres.</param>
        public RechercheController(IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            this.artisteRepository = artisteRepository;
            this.titreRepository = titreRepository;
            this.model = new RechercheViewModel();
        }

        /// <summary>
        /// Accesseur à la page de recherche.
        /// </summary>
        /// <returns>Page de recherche.</returns>
        [HttpPost]
        public IActionResult Index()
        {
            this.model.SearchedItem = this.Request.Form["searchedItem"].ToString();
            this.model.Artistes = this.artisteRepository.FindAll().Where(A => A.Nom.ToLower().Contains(this.model.SearchedItem.ToLower())).ToList();
            this.model.Titres = this.titreRepository.FindAll().Where(T => T.Libelle.ToLower().Contains(this.model.SearchedItem.ToLower())).ToList();
            this.model.Artistes.ForEach(artiste =>
            {
                artiste.Titres.ToList().ForEach(artisteTitre =>
                {
                    if (!this.model.Titres.Exists(recordedTitre => recordedTitre.Libelle == artisteTitre.Libelle))
                    {
                        this.model.Titres.Add(artisteTitre);
                    }
                });
            });
            this.model.Titres = this.model.Titres.OrderBy(T => T.Libelle).ToList();

            return this.View(this.model);
        }
    }
}
