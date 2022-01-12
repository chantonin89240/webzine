namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;
    using Webzine.Repository.Contracts;
    using Webzine.Repository;
    using Webzine.Entity;

    public class RechercheController : Controller
    {
        private IArtisteRepository _artisteRepository;
        private ITitreRepository _titreRepository;

        RechercheController(IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            this._artisteRepository = artisteRepository;
            this._titreRepository = titreRepository;
        }

        [HttpPost]
        public IActionResult Index()
        {
            string searchedItem = Request.Form["searchedItem"].ToString();
            List<Artiste> artistes = _artisteRepository.FindAll().Where(A => A.Nom.ToLower().Contains(searchedItem.ToLower())).ToList();
            List<Titre> titres = _titreRepository.FindAll().Where(T => T.Libelle.ToLower().Contains(searchedItem.ToLower())).ToList();
            artistes.ForEach(artiste =>
            {
                artiste.Titres.ToList().ForEach(artisteTitre =>
                {
                    if (!titres.Exists(recordedTitre => recordedTitre.Libelle == artisteTitre.Libelle))
                    {
                        titres.Add(artisteTitre);
                    }
                });
            });
            titres = titres.OrderBy(T => T.Libelle).ToList();

            RechercheViewModel model = new RechercheViewModel(artistes, titres, searchedItem);
            //model.Rechercher()

            return this.View(model);
        }

        //[HttpPost]
        //public IActionResult Rechercher()
        //{


        //    //get recherche viewmodel

        //    return this.View(model);
        //}

    }
}
