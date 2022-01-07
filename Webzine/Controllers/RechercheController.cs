namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.ViewModels;
    using Webzine.Repository;
    using Webzine.Entity;

    public class RechercheController : Controller
    {
        private LocalArtisteRepository _artisteRepository = new LocalArtisteRepository();
        private LocalTitreRepository _titreRepository = new LocalTitreRepository();

        public IActionResult Index()
        {
            string searchedItem = Request.Form["searchedItem"].ToString();
            List<Artiste> artistes = _artisteRepository.FindAll().Where(A => A.Nom.ToLower().Contains(searchedItem.ToLower())).ToList();
            List<Titre> titres = _titreRepository.FindAll().Where(T => T.Libelle.ToLower().Contains(searchedItem.ToLower())).ToList();

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
