using Webzine.Entity;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;

namespace Webzine.ViewModels
{
    //using Webzine.Entity;

    public class RechercheViewModel : Controller
    {


        private string searchedItem;

        private List<Artiste> artistes;

        private List<Titre> titres;

        /// <summary>
        /// Accède aux tites résultats de la recherche.
        /// </summary>
        public List<Titre> Titres { get { return titres; } }

        /// <summary>
        /// Accède le nom de la recherche.
        /// </summary>
        public string SearchedItem { get { return searchedItem; } }

        /// <summary>
        /// Accède aux artiste résultats de la recherche.
        /// </summary>
        public List<Artiste> Artistes { get { return artistes; } }

        /// <summary>
        /// Produit une instance de modèle dans la page Recherche.
        /// Contient des artistes, des titres et une chaine searchedItem.
        /// </summary>
        public RechercheViewModel()
        {
            searchedItem = string.Empty;
            artistes = new List<Artiste>();
            titres = new List<Titre>();
        }

        /// <summary>
        /// Génère une recherche automatique à partir d'une chaine clé.
        /// </summary>
        /// <param name="search">
        /// La chaine de charactères à rechercher dans les données.
        /// </param>
        public RechercheViewModel(string search)
        {
            artistes = new List<Artiste>();
            titres = new List<Titre>();

            searchedItem = search;
            titres = TitreFactory.CreateTitre().ToList().FindAll(titre => titre.Libelle.ToLower().IndexOf(search.ToLower()) != -1);
            artistes = ArtisteFactory.CreateArtiste().ToList().FindAll(artiste => artiste.Nom.ToLower().IndexOf(search.ToLower()) != -1);
        }

    }
}