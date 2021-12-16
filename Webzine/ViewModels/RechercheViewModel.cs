using Webzine.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.ViewModels
{
    //using Webzine.Entity;

    public class RechercheViewModel : Controller
    {
        private string searchedItem;
        public string SearchedItem { get { return searchedItem; } set { searchedItem = value; } }


        private List<Artiste> artistes;
        public List<Artiste> Artistes { get { return artistes; } set { artistes = value; } }

        private List<Titre> titres;
        public List<Titre> Titres { get { return titres; } set { titres = value; } }



        //Rechercher() => get Artistes and Titres from DB


        /// <summary>
        /// Corresponds au modèle dans la page Recherche.
        /// Contient des artistes, des titres et une chaine searchedItem.
        /// </summary>
        public RechercheViewModel()
        {
            searchedItem = "";
            artistes = new List<Artiste>();
            titres = new List<Titre>();
        }


        //public RechercheViewModel(String SearchedItem)?

    }
}