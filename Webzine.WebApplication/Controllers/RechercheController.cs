namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;
    using Webzine.Repository.Contracts;
   
    using Webzine.Entity;

    public class RechercheController : Controller
    {
        private IArtisteRepository artisteRepository;
        private ITitreRepository titreRepository;
        private RechercheViewModel model;

        public RechercheController(IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            this.artisteRepository = artisteRepository;
            this.titreRepository = titreRepository;
            this.model = new RechercheViewModel();
        }

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
