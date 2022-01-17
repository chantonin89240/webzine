namespace Webzine.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le groupement de données utilisé par la page Recherche.
    /// </summary>
    public class RechercheViewModel
    {
        /// <summary>
        /// Accède aux tites résultats de la recherche.
        /// </summary>
        public List<Titre> Titres { get; set; } = new List<Titre>();

        /// <summary>
        /// Accède le nom de la recherche.
        /// </summary>
        public string SearchedItem { get; set; } = string.Empty;

        /// <summary>
        /// Accède aux artiste résultats de la recherche.
        /// </summary>
        public List<Artiste> Artistes { get; set; } = new List<Artiste>();

        /// <summary>
        /// Formate la durée d'un Titre sous forme "?M:SS".
        /// </summary>
        /// <param name="t">title to format.</param>
        /// <returns>Chaine de charactères sous format "?M:SS".</returns>
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