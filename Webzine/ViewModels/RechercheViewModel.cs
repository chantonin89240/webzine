namespace Webzine.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Factory;

    //using Webzine.Entity;

    public class RechercheViewModel
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
            this.searchedItem = string.Empty;
            this.artistes = new List<Artiste>();
            this.titres = new List<Titre>();
        }

        public RechercheViewModel(List<Artiste> artistes, List<Titre> titres, string search)
        {
            this.searchedItem = search;
            this.artistes = artistes;
            this.titres = titres;
        }

        /// <summary>
        /// Formats the length of a title to m:ss format
        /// </summary>
        /// <param name="t">title to format</param>
        /// <returns>mm:ss format.</returns>
        public string FormatLength(Titre t)
        {
            string output = ((t.Duree - (t.Duree % 60)) / 60) + ":";
            if (t.Duree % 60 < 10)
            {
                output += "0";
            }

            output += (t.Duree % 60).ToString();
            return output;
        }
    }
}